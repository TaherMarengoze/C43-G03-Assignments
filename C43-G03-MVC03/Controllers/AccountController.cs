using Company.Data.Models;
using Company.Service.Helper;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers;

public class AccountController(UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : Controller
{

    #region Sign Up
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult>SignUp(SignupViewModel inputs)
    {
        if (!ModelState.IsValid)
        {
            return View(inputs);
        }

        var newUser = new ApplicationUser
        {
            UserName = inputs.Email.Split('@')[0],
            Email = inputs.Email,
            FirstName = inputs.FirstName,
            LastName = inputs.LastName,
            IsActive = true,
        };

        var result = await userManager.CreateAsync(newUser, inputs.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View(inputs);
        }

        return RedirectToAction(nameof(SignIn));
    }
    #endregion

    #region Log In
    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LoginViewModel login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }

        var user = await userManager.FindByEmailAsync(login.Email);

        if (user is null)
        {
            ModelState.AddModelError("IncorrectUser", "No user with the entered email registered in the system's database");
            return View(login);
        }

        if (!await userManager.CheckPasswordAsync(user, login.Password))
        {
            ModelState.AddModelError("IncorrectPassword", "Incorrect password. Passwords are case sensitive; check for Caps lock");
            return View(login);
        }

        var result = await signInManager.PasswordSignInAsync(user,
            login.Password, login.RememberMe, true);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("LoginError", "Failed to log in to the system");
            return View(login);
        }

        return RedirectToAction("Index", "Home");
    }
    #endregion

    public new async Task<IActionResult> SignOut()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction(nameof(SignIn));
    }

    public IActionResult ForgetPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel inputs)
    {
        if (!ModelState.IsValid)
        {
            return View(inputs);
        }

        var user = await userManager.FindByEmailAsync(inputs.Email);

        if (user is null)
        {
            ModelState.AddModelError("InvalidEmail", "Entered email do not exist in the system's database");
            return View(inputs);
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        var url = Url.Action("ResetPassword", "Account",
            new { Email = inputs.Email, Token = token },
            Request.Scheme);

        var email = new Email
        {
            Body = url,
            Subject = "Reset Password",
            To = inputs.Email
        };

        EmailSettings.SendEmail(email);

        return RedirectToAction(nameof(CheckYouInbox));
    }

    public IActionResult CheckYouInbox()
    {
        return View();
    }

    public IActionResult ResetPassword(string Email, string Token)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel inputs)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByEmailAsync(inputs.Email);

            if (user is not null)
            {
                var result = await userManager.ResetPasswordAsync(user, inputs.Token, inputs.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(LogIn));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
        }

        return View(inputs);
    }
}
