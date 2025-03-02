using System.ComponentModel.DataAnnotations.Schema;

namespace C43_G03_EF02.Models
{
    [Table("Depts", Schema = "Managment")]
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InstructorId { get; set; }

        public DateTime HiringDate { get; set; }
    }
}
