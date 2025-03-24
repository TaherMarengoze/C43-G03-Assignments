using Company.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Contexts;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(x=>x.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Department>()
            .HasIndex(x => x.Code)
            .IsUnique();

        modelBuilder.Entity<Department>()
            .Property(x => x.Id)
            .UseIdentityColumn(10, 10);

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }
}
