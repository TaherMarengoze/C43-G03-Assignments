using AutoMapper;
using Domain.Contracts;
using Services.Abstraction;

namespace Services;

public sealed class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServiceManager
{
    private readonly Lazy<IProductService> _productService =
        new(() => new ProductService(unitOfWork, mapper));

    public IProductService ProductService => _productService.Value;
}
