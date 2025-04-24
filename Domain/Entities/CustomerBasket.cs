namespace Domain.Entities;

public class CustomerBasket
{
    public string Id { get; set; }

    public IEnumerable<BasketItem> BasketItems { get; set; }
}
