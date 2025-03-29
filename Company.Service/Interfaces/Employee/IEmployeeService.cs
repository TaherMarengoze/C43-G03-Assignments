using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Interfaces.Employee;

public interface IEmployeeService
{
    EmployeeDto? GetById(int? id);

    IEnumerable<EmployeeDto> GetAll();

    void Add(EmployeeDto entity);

    void Update(EmployeeDto entity);

    void Delete(EmployeeDto entity);

    IEnumerable<EmployeeDto> GetByName(string name);
}
