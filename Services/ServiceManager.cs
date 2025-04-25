using AutoMapper;
using Domain.Contracts;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services.Abstraction;
using Shared.Dto.Identity;

namespace Services;

public sealed class ServiceManager(IUnitOfWork unitOfWork,
                                   IMapper mapper,
                                   IBasketRepository basketRepository,
                                   UserManager<User> userManager,
                                   IOptions<JwtOptions> options)
    : IServiceManager
{
    private readonly Lazy<IProductService> _productService =
        new(() => new ProductService(unitOfWork, mapper));

    private readonly Lazy<IBasketService> _basketService =
        new(() => new BasketService(basketRepository, mapper));

    private readonly Lazy<IAuthenticationService> _authenticationService =
        new(() => new AuthenticationService(userManager, mapper, options));

    public IProductService ProductService => _productService.Value;

    public IBasketService BasketService => _basketService.Value;

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
