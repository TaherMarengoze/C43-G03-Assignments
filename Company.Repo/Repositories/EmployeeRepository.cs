using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repo.Interfaces;

namespace Company.Repo.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private readonly CompanyDbContext _context;

    public EmployeeRepository(CompanyDbContext context) : base(context)
    {
        _context = context;
    }

    public Employee? GetByName(string name)
    {
        return _context.Employees.FirstOrDefault(x =>
            x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public IEnumerable<Employee> GetByAddress(string address)
    {
        return _context.Employees.Where(x => x.Address != null &&
            x.Address.Contains(address, StringComparison.CurrentCultureIgnoreCase));
    }
}
