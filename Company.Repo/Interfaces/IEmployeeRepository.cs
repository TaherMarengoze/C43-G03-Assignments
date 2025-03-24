using Company.Data.Models;

namespace Company.Repo.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Employee? GetByName(string name);

    IEnumerable<Employee> GetByAddress(string address);
}
