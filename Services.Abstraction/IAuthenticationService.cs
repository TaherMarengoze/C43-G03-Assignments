using Shared.Dto.Identity;

namespace Services.Abstraction;

public interface IAuthenticationService
{
    Task <UserResultDto> LoginAsync(LoginDto loginDto);

    Task<UserResultDto> RegisterAsync(RegisterDto registerDto);
}
