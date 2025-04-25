using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Services.Abstraction;
using Shared.Dto.Identity;

namespace Services;

public class AuthenticationService(UserManager<User> userManager,
                                   IMapper mapper)
    : IAuthenticationService
{
    public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email) ??
            throw new UnauthorizedException($"Email '{loginDto.Email}' does not exist!");

        bool isCorrectPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!isCorrectPassword)
        {
            throw new UnauthorizedException($"Incorrect password!");
        }

        return new UserResultDto(user.DisplayName, user.Email!, "jwtToken");
    }

    public Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}
