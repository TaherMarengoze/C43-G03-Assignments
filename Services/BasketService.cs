using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Abstraction;
using Shared.Dto.Basket;

namespace Services;

public class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
{
    public async Task<BasketDto> GetBasketAsync(string id)
    {
        var basket = await basketRepository.GetBasketAsync(id);

        if (basket == null)
        {
            throw new BasketNotFoundException(id);
        }

        var mappedBasket = mapper.Map<BasketDto>(basket);

        return mappedBasket;
    }

    public async Task<BasketDto> UpdateBasketAsync(BasketDto basket)
    {
        var customerBasket = mapper.Map<CustomerBasket>(basket);

        var updatedBasket = await basketRepository.UpdateBasketAsync(customerBasket);

        if (updatedBasket == null)
        {
            throw new Exception("Unable to update basket, now!");
        }

        var mappedUpdatedBasket = mapper.Map<BasketDto>(updatedBasket);

        return mappedUpdatedBasket;
    }

    public async Task<bool> DeleteBasketAsync(string id)
    {
        return await basketRepository.DeleteBasketAsync(id);
    }
}
