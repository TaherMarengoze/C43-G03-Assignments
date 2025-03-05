using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF03.Models;

[PrimaryKey(nameof(InstructorId), nameof(CourseId))]
public class InstructorCourse
{
    public int InstructorId { get; set; }

    [ForeignKey(nameof(InstructorId))]
    public Instructor? Instructor { get; set; }

    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course? Course { get; set; }

    public double? Evaluation { get; set; }
}