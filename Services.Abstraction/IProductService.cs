using Shared.Dto.Product;

namespace Services.Abstraction;

public interface IProductService
{
    Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParams specsParams);

    Task<ProductResultDto> GetProductByIdAsync(int id);

    Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();

    Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
}
