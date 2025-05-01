#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Domain.Entities.Order;

public class OrderItem : BaseEntity<Guid>
{
    public ProductInOrderItem Product { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
