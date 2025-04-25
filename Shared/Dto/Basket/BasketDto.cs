namespace Shared.Dto.Basket;

public record BasketDto
{
    public string Id { get; set; }

    public IEnumerable<BasketItemDto> Items { get; set; }
}
