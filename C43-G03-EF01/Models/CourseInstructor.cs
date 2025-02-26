namespace C43_G03_EF01.Models
{
    public class CourseInstructor
    {
        public int Id { get; set; }

        public int InstructorId { get; set; }

        public int CourseId { get; set; }

        public double? Evaluation { get; set; }
    }
}
