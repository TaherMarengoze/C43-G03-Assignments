using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Http;

namespace Company.Service.Interfaces.Employee.Dto;

public class EmployeeDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int Age { get; set; }

    public string? Address { get; set; }

    public decimal? Salary { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? HiringDate { get; set; }

    public string? ImageUrl { get; set; }

    public IFormFile? Image { get; set; }

    public int? DepartmentId { get; set; }

    public DepartmentDto? Department { get; set; }

    public DateTime CreatedAt { get; set; }
}
