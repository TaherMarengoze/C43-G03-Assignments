namespace Company.Data.Models;

public class Department : ModelMetadata
{
    public required string Name { get; set; }

    public required string Code { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
