using Company.Data.Models;

namespace Company.Repo.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    IEnumerable<Employee> GetByName(string name);

    IEnumerable<Employee> GetByAddress(string address);
}
