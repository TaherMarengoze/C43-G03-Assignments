using System.Text.Json;

namespace Shared.ErrorModels;

public class ErrorDetails
{
    public int StatusCode { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string ErrorMessage { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public IEnumerable<string>? Errors { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
