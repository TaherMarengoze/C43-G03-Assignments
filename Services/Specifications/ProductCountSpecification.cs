using Domain.Contracts;
using Domain.Entities;
using Shared.Dto.Product;

namespace Services.Specifications;

public class ProductCountSpecification : Specification<Product>
{
    public ProductCountSpecification(ProductSpecificationParams specsParams)
        : base(ExpressionBuilders.ForProductSpecificationParams(specsParams))
    { }
}
