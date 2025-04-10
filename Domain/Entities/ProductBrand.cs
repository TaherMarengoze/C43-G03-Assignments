namespace Domain.Entities;

public class ProductBrand : BaseEntity<int>
{
    public required string Name { get; set; }
}
