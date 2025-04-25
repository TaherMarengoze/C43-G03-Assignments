using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.Dto.Identity;

namespace Presentation.Controllers;

public class AuthenticationController(IServiceManager serviceManager)
    : ApiController
{
    [HttpPost("Register")]
    public async Task<ActionResult<UserResultDto>> Register(RegisterDto registerDto)
        => Ok(await serviceManager.AuthenticationService.RegisterAsync(registerDto));

    [HttpPost("Login")]
    public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        => Ok(await serviceManager.AuthenticationService.LoginAsync(loginDto));
}
