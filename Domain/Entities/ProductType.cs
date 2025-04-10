namespace Domain.Entities;

public class ProductType : BaseEntity<int>
{
    public required string Name { get; set; }
}
