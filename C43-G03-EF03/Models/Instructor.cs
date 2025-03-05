using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C43_G03_EF03.Models;

public class Instructor
{
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public required string Name { get; set; }

    public string? Address { get; set; }

    public double? Salary { get; set; }

    public double? HourRate { get; set; }

    public double? Bonus { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department? Department { get; set; }

    [InverseProperty(nameof(Department.ManagingInstructor))]
    public Department? ManagedDepartment { get; set; }

    [InverseProperty(nameof(InstructorCourse.Instructor))]
    public ICollection<InstructorCourse>? InstructorCourses { get; set; }
}