namespace Domain.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IEnumerable<string> errors)
        : base($"Validation Error")
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; set; }
}
