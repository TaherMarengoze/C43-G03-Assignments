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

    public IEnumerable<Employee> GetByName(string name)
    {
        return _context.Employees.Where(e =>
            e.Name.Trim().Contains(name.Trim(), StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    public IEnumerable<Employee> GetByAddress(string address)
    {
        return _context.Employees.Where(x => x.Address != null &&
            x.Address.Contains(address, StringComparison.CurrentCultureIgnoreCase));
    }
}
