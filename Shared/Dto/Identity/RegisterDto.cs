#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Shared.Dto.Identity;

public record RegisterDto
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string DisplayName { get; set; }

    public string? PhoneNumber { get; set; }
}
