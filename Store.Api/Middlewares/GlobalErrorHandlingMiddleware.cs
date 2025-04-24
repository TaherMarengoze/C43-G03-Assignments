using System.Net;
using Domain.Exceptions;
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
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = ex switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        ErrorDetails response = new()
        {
            StatusCode = httpContext.Response.StatusCode,
            ErrorMessage = ex.Message,
        };

        await httpContext.Response.WriteAsync($"{response}");
    }
}
