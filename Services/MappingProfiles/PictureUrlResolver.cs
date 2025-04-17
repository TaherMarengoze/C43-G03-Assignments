using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared.Dto.Product;

namespace Services.MappingProfiles;

public class PictureUrlResolver(IConfiguration config) : IValueResolver<Product, ProductResultDto, string?>
{
    public string Resolve(Product source, ProductResultDto destination, string? destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl))
        {
            return string.Empty;
        }

        return $"{config["BaseUrl"]}{source.PictureUrl}";
    }
}
