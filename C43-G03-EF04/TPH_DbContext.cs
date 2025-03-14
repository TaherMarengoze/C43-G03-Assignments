using C43_G03_EF04.Generation_Ways;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF04;

public class TPHDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=.; Database=EF4;Trusted_Connection=True; TrustServerCertificate=True;"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Car>().HasBaseType<Vehicle>();
        //modelBuilder.Entity<Truck>().HasBaseType<Vehicle>();

        modelBuilder.Entity<Vehicle>()
            .HasDiscriminator<string>("VehicleFamily") //if call chain ended here the Car value will be "Car" as per the class name as well as the truck
            .HasValue<Car>("CarFamily") //if call chain ended here the Truck class will default to the class name "Truck"
            .HasValue<Truck>("TruckFamily")
            ;
    }

    public DbSet<Vehicle> Vehicles { get; set; } //removing this and adding the derived classes and not adding OnModelCreating will result in TPCC generation

    //public DbSet<Car> Cars { get; set; }
    public DbSet<Truck> Trucks { get; set; }
}
