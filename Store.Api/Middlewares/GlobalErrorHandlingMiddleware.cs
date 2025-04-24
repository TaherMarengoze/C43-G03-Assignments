using System.Net;
using Shared.ErrorModels;

namespace Store.Api.Middlewares;

public class GlobalErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<GlobalErrorHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError($"Oops, bad thing happened: {ex}");

            await HandleException(httpContext, ex);
        }
    }

    private async Task HandleException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        httpContext.Response.ContentType = "application/json";

        var response = new ErrorDetails
        {
            StatusCode = 100,
            ErrorMessage = ex.Message,
        };

        //TODO:

        response.StatusCode = httpContext.Response.StatusCode;

        await httpContext.Response.WriteAsync($"{response}");
    }
}
