using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models;

public class ResetPasswordViewModel
{
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$", ErrorMessage =
        "Password min length: 6 and must contain 1 lowercase, 1 uppercase, 1 digit, 1 special characher")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare(nameof(Password), ErrorMessage = "Confirm Password do not match the Password")]
    public required string ConfirmPassword { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }

}
