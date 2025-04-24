using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Abstraction;
using Services.Specifications;
using Shared;
using Shared.Dto.Product;

namespace Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParams specsParams)
    {
        var specs =
            new ProductWithFilterSpecification(specsParams);

        var products = await unitOfWork
            .GetRepository<Product,int>().GetAllAsync(specs);

        var mappedProducts = mapper
            .Map<IEnumerable<ProductResultDto>>(products);

        var countSpecs = new ProductCountSpecification(specsParams);
        var productsWithSpecsCount = await unitOfWork
            .GetRepository<Product, int>().CountAsync(countSpecs);

        var paginatedProducts =
            new PaginatedResult<ProductResultDto>(specsParams.PageIndex,
            specsParams.PageSize,
            productsWithSpecsCount,
            mappedProducts);

        return paginatedProducts;
    }

    public async Task<ProductResultDto> GetProductByIdAsync(int id)
    {
        var specs = new ProductWithFilterSpecification(id);

        var product = await unitOfWork
            .GetRepository<Product,int>().GetAsync(specs);

        if (product is null)
        {
            throw new ProductNotFoundException(id);
        }

        var mappedProduct = mapper
            .Map<ProductResultDto>(product);

        return mappedProduct;
    }

    public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
    {
        var types = await unitOfWork
            .GetRepository<ProductType, int>().GetAllAsync();

        var mappedTypes = mapper
            .Map<IEnumerable<TypeResultDto>>(types);

        return mappedTypes;
    }

    public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
    {
        var brands = await unitOfWork
            .GetRepository<ProductBrand, int>().GetAllAsync();

        var mappedBrands = mapper
            .Map<IEnumerable<BrandResultDto>>(brands);

        return mappedBrands;
    }
}
