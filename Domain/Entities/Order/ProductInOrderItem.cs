#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Domain.Entities.Order;

public class ProductInOrderItem
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string PictureUrl { get; set; }
}
