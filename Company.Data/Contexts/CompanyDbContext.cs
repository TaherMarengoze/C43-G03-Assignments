using Company.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Contexts;

public class CompanyDbContext : IdentityDbContext<ApplicationUser>
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

        //modelBuilder.Entity<ModelMetadata>()
        //    .HasQueryFilter(e => !e.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }
}
