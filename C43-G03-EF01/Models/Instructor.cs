namespace C43_G03_EF01.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Bonus { get; set; }

        public double? Salary { get; set; }

        public string? Address { get; set; }

        public double? HourRate { get; set; }

        public int DepartmentId { get; set; }
    }
}
