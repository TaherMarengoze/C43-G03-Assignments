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
        const StringComparison ignoreCase = StringComparison.CurrentCultureIgnoreCase;

        return _context.Employees.AsEnumerable().Where(e =>
            e.Name.Trim().Contains(name.Trim(), ignoreCase)
            || (e.Email?.Trim().Contains(name.Trim(), ignoreCase) ?? true)
            || (e.Phone?.Trim().Contains(name.Trim(), ignoreCase) ?? true)
        ).ToList();
    }

    public IEnumerable<Employee> GetByAddress(string address)
    {
        return _context.Employees.Where(x => x.Address != null &&
            x.Address.Contains(address, StringComparison.CurrentCultureIgnoreCase));
    }
}
