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

    public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            DisplayName = registerDto.DisplayName,
            PhoneNumber = registerDto.PhoneNumber,
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors
                .Select(err => err.Description).ToList();

            throw new ValidationException(errors);
        }

        return new UserResultDto(user.DisplayName, user.Email!, "jwtToken");
    }
}
