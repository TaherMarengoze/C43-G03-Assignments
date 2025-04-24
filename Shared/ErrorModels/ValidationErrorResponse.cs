#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Shared.ErrorModels;

public class ValidationErrorResponse
{
    public int StatusCode { get; set; }

    public string ErrorMessage { get; set; }

    public IEnumerable<ValidationError>? Errors { get; set; }
}

public class ValidationError
{
    public string Key { get; set; }

    public IEnumerable<string> Errors { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
