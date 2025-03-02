using System.ComponentModel.DataAnnotations;

namespace C43_G03_EF02.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Range(0, 100)]
        public double? Grade { get; set; }
    }
}