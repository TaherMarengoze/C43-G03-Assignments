using Store.Api.Extensions;
using Store.Api.Middlewares;

namespace Store.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.InfrastructureServices(builder.Configuration);
        builder.Services.AddCoreServices(builder.Configuration);
        builder.Services.AddPresentationServices();

        var app = builder.Build();

        await app.RunDbInitializerAsync();

        app.UseMiddleware<GlobalErrorHandlingMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
