using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;

namespace Store.Api.Factories;

public class ApiResponseFactory
{
    public static ActionResult CustomValidationErrorResponse(ActionContext context)
    {
        var errors = context.ModelState
            .Where(err => err.Value.Errors.Any())
            .Select(err => new ValidationError
            {
                Key = err.Key,
                Errors = err.Value.Errors.Select(e => e.ErrorMessage)
            });

        var validationResponse = new ValidationErrorResponse
        {
            StatusCode = (int)HttpStatusCode.BadRequest,
            ErrorMessage = "Validation Error",
            Errors = errors
        };

        return new BadRequestObjectResult(validationResponse);
    }
}
