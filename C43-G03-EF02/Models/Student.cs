using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C43_G03_EF02.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "First Name")]
        public required string FName { get; set; }

        [Required, Display(Name = "Last Name")]
        public required string LName { get; set; }

        public string? Address { get; set; }

        public int? Age { get; set; }

        public int DepartmentId { get; set; }

        [NotMapped]
        public string FullName => $"{FName} {LName}";
    }
}
