using System.Text.Json;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence;

public class DbInitializer(StoreDbContext context) : IDbInitializer
{
    public async Task InitializeAsync()
    {
        //CheckForPendingMigrations();

        try
        {
            await SeedEntityAsync<ProductType>("types.json");
            await SeedEntityAsync<ProductBrand>("brands.json");
            await SeedEntityAsync<Product>("products.json");
        }
        catch (Exception)
        {
            throw;
        }
        
    }

    private void SeedProductTypes()
    {
        if (!context.ProductTypes.Any())
        {
            var typesDataSource = File.ReadAllText(
                @"../Infrastructure/Persistence/Data/Seeding/types.json");

            var types =
                JsonSerializer.Deserialize<List<ProductType>>(typesDataSource);

            if (types != null && types.Count != 0)
            {
                context.ProductTypes.AddRange(types);
                context.SaveChanges();
            }
        }
    }

    private void SeedProductBrands()
    {
        if (!context.ProductBrands.Any())
        {
            var brandsDataSource = File.ReadAllText(
                @"../Infrastructure/Persistence/Data/Seeding/brands.json");

            var brands =
                JsonSerializer.Deserialize<List<ProductBrand>>(brandsDataSource);

            if (brands != null && brands.Count != 0)
            {
                context.ProductBrands.AddRange(brands);
                context.SaveChanges();
            }
        }
    }

    private void CheckForPendingMigrations()
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }

    private async Task SeedEntityAsync<TEntity>(string entityFileName) where TEntity : class
    {
        if (!context.Set<TEntity>().Any())
        {
            var dataSource = File.ReadAllText(
                @$"../Persistence/Data/Seeding/{entityFileName}");

            var entities =
                JsonSerializer.Deserialize<List<TEntity>>(dataSource);

            if (entities != null && entities.Count != 0)
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }
    }
}
