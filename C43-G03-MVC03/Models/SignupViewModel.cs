using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models;

public class SignupViewModel
{
    [Required(ErrorMessage = "First Name is required")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Lasr Name is required")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$", ErrorMessage =
        "Password min length: 6 and must contain 1 lowercase, 1 uppercase, 1 digit, 1 special characher")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare(nameof(Password), ErrorMessage = "Confirm Password do not match the Password")]
    public required string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Compliance to Agreement is required")]
    public bool IsAgree { get; set; }
}
