using AutoMapper;
using Domain.Entities.Identity;
using Shared.Dto.Identity;

namespace Services.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}
