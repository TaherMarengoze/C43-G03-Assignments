using System.Text.Json;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Identity;

namespace Persistence;

public class DbInitializer(StoreDbContext context,
                           StoreIdentityDbContext identityDbContext,
                           RoleManager<IdentityRole> roleManager,
                           UserManager<User> userManager)
    : IDbInitializer
{
    public async Task InitializeAsync()
    {
        await CheckForPendingMigrationsAsync(context);

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

    public async Task InitializeIdentityAsync()
    {
        await CheckForPendingMigrationsAsync(identityDbContext);

        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        }

        if (!userManager.Users.Any())
        {
            var superAdminUser = new User
            {
                DisplayName = "Super Admin",
                Email = "superadmin@gmail.com",
                UserName = "SuperAdmin",
                PhoneNumber = "1234567890"
            };

            var adminUser = new User
            {
                DisplayName = "Admin",
                Email = "admin@gmail.com",
                UserName = "Admin",
                PhoneNumber = "0987654321"
            };

            await userManager.CreateAsync(superAdminUser, "Passw0rd");
            await userManager.CreateAsync(adminUser, "Passw0rd");

            await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    private static async Task CheckForPendingMigrationsAsync(DbContext dbContext)
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
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
