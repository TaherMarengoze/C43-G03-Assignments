using Domain.Contracts;
using Domain.Entities;
using Shared.Dto.Product;

namespace Services.Specifications;

public class ProductWithFilterSpecification : Specification<Product>
{
    //Many Products
    public ProductWithFilterSpecification(ProductSpecificationParams specs)
        : base(ExpressionBuilders.ForProductSpecificationParams(specs))
    {
        AddInclude(p => p.ProductBrand!);
        AddInclude(p => p.ProductType!);

        ApplyPagination(specs.PageIndex, specs.PageSize);

        ApplySortingOptions(specs.Sort);
    }

    private void ApplySortingOptions(SortOptions? sortOptions)
    {
        if (sortOptions is not null)
        {
            switch (sortOptions)
            {
                case SortOptions.NameAsc:
                SetOrderBy(p => p.Name);
                break;

                case SortOptions.NameDesc:
                SetOrderByDesc(p => p.Name);
                break;

                case SortOptions.PriceAsc:
                SetOrderBy(p => p.Price);
                break;

                case SortOptions.PriceDesc:
                SetOrderByDesc(p => p.Price);
                break;

                default:
                SetOrderBy(p => p.Name);
                break;
            }
        }
    }
    
    //One Product
    public ProductWithFilterSpecification(int id) : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductBrand!);
        AddInclude(p => p.ProductType!);
    }
}
