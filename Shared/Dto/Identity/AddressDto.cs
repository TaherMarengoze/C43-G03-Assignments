#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Shared.Dto.Identity;

public record AddressDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}
