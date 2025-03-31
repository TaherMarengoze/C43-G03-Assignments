using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models;

public class ForgetPasswordViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public required string Email { get; set; }
}
