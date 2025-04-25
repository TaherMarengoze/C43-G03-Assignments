using Services.Abstraction;
using Services;
using Shared.Dto.Identity;

namespace Store.Api.Extensions;

public static class CoreServicesExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddAutoMapper(typeof(ServiceManager).Assembly);
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        return services;
    }
}
