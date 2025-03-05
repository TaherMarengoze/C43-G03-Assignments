using System.Reflection;
using C43_G03_EF03.Models;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF03
{
    public class ItiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.; Database=ITI_S3;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Department>().Property(e => e.Id)
                .UseIdentityColumn(10, 10);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorCourse> InstructorCoures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set; }
        public DbSet<Topic> Topics { get; set; }

    }
}