namespace Shared.Dto.Product;

public class ProductSpecificationParams
{
    public int? BrandId { get; set; }

    public int? TypeId { get; set; }

    public string? Search { get; set; }

    public SortOptions? Sort { get; set; }
}
