namespace C43_G03_EF01.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Duration { get; set; }

        public int TopicId { get; set; }
    }
}
