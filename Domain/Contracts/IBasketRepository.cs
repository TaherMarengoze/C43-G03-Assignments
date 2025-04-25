using Domain.Entities;


namespace Domain.Contracts;

public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string id);

    /// <summary>
    /// Used for Create and Update.
    /// </summary>
    /// <param name="basket"></param>
    /// <returns></returns>
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket, TimeSpan? timeToLive = null);

    Task<bool> DeleteBasketAsync(string id);
}
