using System.Reflection;
using C43_G03_EF02.Models;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF02
{
    public class ItiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.; Database=ITI_S2;Trusted_Connection=True; TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<StudentCourse>()
                .HasKey(x => x.Id)
                ;

            modelBuilder.Entity<Instructor>()
                .HasKey(x => x.Id)
                ;

            modelBuilder.Entity<CourseInstructor>()
                .HasKey(x => x.Id)
                ;
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<CourseInstructor> CoursesInstructors { get; set; }
    }


}

