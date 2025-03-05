using System.ComponentModel.DataAnnotations;

namespace C43_G03_EF03.Models;

public class Topic
{
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(50)]
    public required string Name { get; set; }
}