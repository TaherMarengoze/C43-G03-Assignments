using Domain.Contracts;
using Domain.Entities;
using Shared.Dto.Product;

namespace Services.Specifications;

public class ProductWithFilterSpecification : Specification<Product>
{
    public ProductWithFilterSpecification(ProductSpecificationParams specs)
        : base(p => ExpressionBuilder(specs,p))
    {
    }

    public ProductWithFilterSpecification(int id) : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductBrand!);
        AddInclude(p => p.ProductType!);
    }

    private static bool ExpressionBuilder(ProductSpecificationParams specs, Product p)
        => true
        && (!specs.BrandId.HasValue || p.BrandId == specs.BrandId)
        && (!specs.TypeId.HasValue || p.TypeId == specs.TypeId)
        ;
}
