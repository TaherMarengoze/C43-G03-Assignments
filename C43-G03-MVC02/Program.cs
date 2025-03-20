
namespace C43_G03_MVC02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //The following line replaced the ConfigureServices method in ASP.NET Core 5
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            //The following line replaced the Configure method in ASP.NET Core 5
            var app = builder.Build();

            app.UseRouting();

            #region Routing before using controllers and views
            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/Product", () => "Product Work");
            //app.MapGet("/Category", () => "Category Work");
            //app.MapGet("/Order", () => "Order Works");

            //app.Use(async (context, next) =>
            //{
            //    Endpoint endpoint = context.GetEndpoint()!;
            //    await next();
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async httpContext => await httpContext.Response.WriteAsync("Hello, MVC World"));

            //    //Parameters (Optional)
            //    endpoints.MapGet("/Products/{id?}", async httpContext =>
            //    {
            //        var id = httpContext.Request.RouteValues["id"];

            //        if (id is null)
            //        {
            //            await httpContext.Response.WriteAsync(
            //                $"<h1>Products works !!</h1>"
            //            );
            //        }
            //        else
            //        {
            //            await httpContext.Response.WriteAsync(
            //                $"Products works !!\nSelected Specific Product\nID = {id}"
            //            );
            //        }
            //    });

            //    //Parameters (Constraints)
            //    endpoints.MapGet("/Orders/{id:int?}/{owner:alpha?}", async httpContext =>
            //    {
            //        await httpContext.Response.WriteAsync(
            //            $"Orders works !!"
            //        );
            //    });

            //});

            //app.Run(async context => await context.Response.WriteAsync("Page not found!"));
            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "/{Controller}/{Action}",
                defaults: new { Controller = "Home", Action = "Index" }
            );

            app.UseStaticFiles();

            app.Run();
        }
    }
}
