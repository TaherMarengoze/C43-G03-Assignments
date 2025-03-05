using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C43_G03_EF03.Models;

public class Department
{
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(50)]
    public required string Name { get; set; }

    [InverseProperty(nameof(Student.Department))]
    public ICollection<Student>? Students { get; set; }

    [InverseProperty(nameof(Instructor.Department))]
    public ICollection<Instructor>? Instructors { get; set; }

    public int? ManagingInstructorId { get; set; }

    [ForeignKey(nameof(ManagingInstructorId))]
    public Instructor? ManagingInstructor { get; set; }

    public DateTime? HiringDate { get; set; }
}