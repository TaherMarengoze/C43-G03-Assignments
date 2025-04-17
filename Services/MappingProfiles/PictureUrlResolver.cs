using AutoMapper;
using Domain.Entities;
using Shared.Dto.Product;

namespace Services.MappingProfiles;

public class PictureUrlResolver : IValueResolver<Product, ProductResultDto, string?>
{
    public string Resolve(Product source, ProductResultDto destination, string? destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl))
        {
            return string.Empty;
        }

        return $"https://localhost:7050/{source.PictureUrl}";
    }
}
