using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Interfaces.Department.Dto;

public class DepartmentDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Code { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
}
