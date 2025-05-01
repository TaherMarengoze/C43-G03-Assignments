#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Domain.Entities.Order;

public class DeliveryMethod : BaseEntity<int>
{
    public string ShortName { get; set; }

    public string Description { get; set; }

    public string DeliveryTime { get; set; }

    public decimal Price { get; set; }

}
