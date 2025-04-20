using Domain.Entities;
using Shared.Dto.Product;
using System.Linq.Expressions;

namespace Services.Specifications;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons

internal static class ExpressionBuilders
{
    internal static Expression<Func<Product, bool>> ForProductSpecificationParams(ProductSpecificationParams specs)
    {
        return p =>
            (!specs.BrandId.HasValue || p.BrandId == specs.BrandId)
            && (!specs.TypeId.HasValue || p.TypeId == specs.TypeId)
            && (string.IsNullOrWhiteSpace(specs.Search) || p.Name.ToLower().Contains(specs.Search.ToLower().Trim()));
    }
}

#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
#pragma warning restore IDE0079 // Remove unnecessary suppression
