using Domain.Contracts;
using Domain.Entities;
using Shared.Dto.Product;

namespace Services.Specifications;

public class ProductWithFilterSpecification : Specification<Product>
{
    //Many Products
    public ProductWithFilterSpecification(ProductSpecificationParams specs)
        : base(p => ExpressionBuilder(specs, p))
    {
        AddInclude(p => p.ProductBrand!);
        AddInclude(p => p.ProductType!);

        if (specs.Sort is not null)
        {
            switch (specs.Sort)
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

    private static bool ExpressionBuilder(ProductSpecificationParams specs, Product p)
        => true
        && (!specs.BrandId.HasValue || p.BrandId == specs.BrandId)
        && (!specs.TypeId.HasValue || p.TypeId == specs.TypeId)
        && (!string.IsNullOrWhiteSpace(specs.Search) ||
            p.Name.Contains(specs.Search!.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase))
        ;
}
