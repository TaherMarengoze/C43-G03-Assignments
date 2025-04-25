#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Shared.Dto.Identity;

public class JwtOptions
{
    public string SecurityKey { get; set; }

    public string Issuer { get; set; }
    
    public string Audiance { get; set; }
    
    public double DurationInDays { get; set; }
}
