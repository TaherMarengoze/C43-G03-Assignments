using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Factories;

namespace Store.Api.Extensions;

public static class PresentationServicesExtension
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(opt =>
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory =
                ApiResponseFactory.CustomValidationErrorResponse;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
