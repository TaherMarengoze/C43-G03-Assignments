using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstraction;
using Shared.Dto.Identity;

namespace Services;

public class AuthenticationService(UserManager<User> userManager,
                                   IMapper mapper,
                                   IOptions<JwtOptions> options)
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

        return new UserResultDto(user.DisplayName, user.Email!,
            await CreateTokenAsync(user));
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

        return new UserResultDto(user.DisplayName, user.Email!,
            await CreateTokenAsync(user));
    }

    private async Task<string> CreateTokenAsync(User user)
    {
        var jwtOptions = options.Value;

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
        };

        var roles = await userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role , role));
        }

        var key =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey));

        var creds =
            new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token =
            new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.UtcNow.AddDays(jwtOptions.DurationInDays),

                audience: jwtOptions.Audiance,
                issuer: jwtOptions.Issuer
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
