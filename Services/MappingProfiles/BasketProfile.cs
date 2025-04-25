using AutoMapper;
using Domain.Entities;
using Shared.Dto.Basket;

namespace Services.MappingProfiles;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<CustomerBasket, BasketDto>().ReverseMap();
        CreateMap<BasketItem, BasketItemDto>().ReverseMap();
    }
}
