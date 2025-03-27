using Company.Data.Models;

namespace Company.Service.Interfaces;

public interface IEmployeeService
{
    Employee? GetById(int id);

    IEnumerable<Employee> GetAll();

    void Add(Employee entity);

    void Update(Employee entity);

    void Delete(Employee entity);

    IEnumerable<Employee> GetByName(string name);
}
