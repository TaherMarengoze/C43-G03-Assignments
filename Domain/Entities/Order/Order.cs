#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Domain.Entities.Order;

public class Order : BaseEntity<Guid>
{
    public string BuyerEmail { get; set; }

    public Address ShippingAddress { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public OrderPaymentStatus PaymentStatus { get; set; } = OrderPaymentStatus.Pending;

    public int? DeliveryMethodId { get; set; }

    public DeliveryMethod DeliveryMethod { get; set; }

    public DateTimeOffset OrderDate { get; set; }

    public decimal Subtotal { get; set; }
}
