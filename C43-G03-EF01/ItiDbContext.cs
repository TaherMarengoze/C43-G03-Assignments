using C43_G03_EF01.Models;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF01
{
    public class ItiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.; Database=ITI;Trusted_Connection=True; TrustServerCertificate=True;");
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
