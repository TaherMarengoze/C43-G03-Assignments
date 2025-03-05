using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF03.Models;

[PrimaryKey(nameof(StudentId), nameof(CourseId))]
public class StudentCourse
{
    public int StudentId { get; set; }

    [ForeignKey(nameof(StudentId))]
    public Student? Student { get; set; }

    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course? Course { get; set; }

    [Range(0, 100)]
    public double? Grade { get; set; }
}