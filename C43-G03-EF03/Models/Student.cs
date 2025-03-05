using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C43_G03_EF03.Models;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string FName { get; set; }

    [Required]
    public required string LName { get; set; }

    public string? Address { get; set; }

    public int? Age { get; set; }

    [InverseProperty(nameof(StudentCourse.Student))]
    public ICollection<StudentCourse>? EnrolledCourses { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department? Department { get; set; }

    [NotMapped]
    public string FullName => $"{FName} {LName}";
}