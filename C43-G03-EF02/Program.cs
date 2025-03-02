using C43_G03_EF02.Models;

namespace C43_G03_EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ItiDbContext context = new();

            context.Departments.Add(new()
            {
                Name = "A",
            });

            context.Instructors.Add(new()
            {
                Name = "Hassan",
                DepartmentId = 1
            });

            context.Students.Add(new()
            {
                FName = "Ahmed",
                LName = "Mohamed",
                DepartmentId = 10,
            });

            context.Add(new Student
            {
                FName = "Test",
                LName = "Test",
            });

            context.Courses.Add(new()
            {
                Id = 100,
                Name = "C#",
                Duration = 72,
            });


            var course1 = context.Courses.FirstOrDefault(c => c.Id == 100);

            if (course1 is not null)
            {
                course1.Description = "C Sharp Course from Beginner to Advanced";

                context.Courses.Update(course1);
            }

            var testStudent = context.Students
                .FirstOrDefault(s => s.FName == "Test");

            if (testStudent is not null)
            {
                context.Remove(testStudent);
            }

            context.SaveChanges();
        }
    }
}
