#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class User : IdentityUser
{
    public string DisplayName { get; set; }

    public Address Address { get; set; }
}
