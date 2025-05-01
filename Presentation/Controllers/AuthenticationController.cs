using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.Dto.Identity;

namespace Presentation.Controllers;

public class AuthenticationController(IServiceManager serviceManager)
    : ApiController
{
    [HttpPost]
    public async Task<ActionResult<UserResultDto>> Register(RegisterDto registerDto)
        => Ok(await serviceManager.AuthenticationService.RegisterAsync(registerDto));

    [HttpPost]
    public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        => Ok(await serviceManager.AuthenticationService.LoginAsync(loginDto));

    [HttpGet]
    public async Task<ActionResult<bool>> IsEmailExist(string email)
        => Ok(await serviceManager.AuthenticationService.IsEmailExistAsync(email));

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserResultDto>> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        
        var result = await serviceManager.AuthenticationService
            .GetUserByEmailAsync(email!);

        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserResultDto>> GetCurrentUserAddress()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var result = await serviceManager.AuthenticationService
            .GetUserAddressAsync(email!);

        return Ok(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<UserResultDto>> UpdateUserAddress(AddressDto addressDto)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var result = await serviceManager.AuthenticationService
            .UpdateUserAddressAsync(email!, addressDto);

        return Ok(result);
    }
}
