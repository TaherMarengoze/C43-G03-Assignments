using System.ComponentModel.DataAnnotations.Schema;

namespace C43_G03_EF03.Models;

public class Course
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public int TopicId { get; set; }

    [ForeignKey(nameof(TopicId))]
    public Topic? Topic { get; set; }

    [InverseProperty(nameof(StudentCourse.Course))]
    public ICollection<StudentCourse>? CourseStudents { get; set; }

    [InverseProperty(nameof(InstructorCourse.Course))]
    public ICollection<InstructorCourse>? CourseInstructors { get; set; }
}