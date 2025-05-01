using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class OrderConfigs : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .OwnsOne(o => o.ShippingAddress,
                address => address.WithOwner());

        builder
            .HasMany(o => o.OrderItems)
            .WithOne();

        builder
            .Property(o => o.PaymentStatus)
            .HasConversion(
                x=> x.ToString(),
                x=>Enum.Parse<OrderPaymentStatus>(x)
            );
    }
}
