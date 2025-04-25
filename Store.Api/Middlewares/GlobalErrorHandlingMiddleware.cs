#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA2254 // Template should be a static expression

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

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                await HandleNotFoundEndpointAsync(httpContext);
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Oops, bad thing happened: {ex}");

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleNotFoundEndpointAsync(HttpContext httpContext)
    {
        ErrorDetails response = new()
        {
            ErrorMessage = $"Endpoint: '{httpContext.Request.Path}', Not Found!",
            StatusCode = (int)HttpStatusCode.NotFound,
        };

        httpContext.Response.ContentType = "application/json";
        
        await httpContext.Response.WriteAsync($"{response}");
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        ErrorDetails response = new()
        {
            ErrorMessage = ex.Message,
            //StatusCode = httpContext.Response.StatusCode,
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = ex switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            UnauthorizedException => (int)HttpStatusCode.Unauthorized,
            ValidationException validationEx => HandleValidationException(validationEx, response),
            _ => (int)HttpStatusCode.InternalServerError
        };

        response.StatusCode = httpContext.Response.StatusCode;

        await httpContext.Response.WriteAsync($"{response}");
    }

    private static int HandleValidationException(ValidationException ex, ErrorDetails errorDetails)
    {
        errorDetails.Errors = ex.Errors;
        return (int)HttpStatusCode.BadRequest;
    }
}
