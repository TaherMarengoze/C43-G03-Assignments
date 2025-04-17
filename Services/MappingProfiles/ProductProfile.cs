using AutoMapper;
using Domain.Entities;
using Shared.Dto.Product;

namespace Services.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResultDto>()
            .ForMember(d => d.BrandName,
                options => options
                    .MapFrom(s => s.ProductBrand!.Name))
            .ForMember(d => d.TypeName,
                options => options
                    .MapFrom(s => s.ProductType!.Name))
            .ForMember(d => d.PictureUrl,
                options => options
                    .MapFrom<PictureUrlResolver>());

        CreateMap<ProductType, TypeResultDto>();
        CreateMap<ProductBrand, BrandResultDto>();
    }
}
