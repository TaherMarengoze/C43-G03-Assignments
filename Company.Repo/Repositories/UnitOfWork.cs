using Company.Data.Contexts;
using Company.Repo.Interfaces;

namespace Company.Repo.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CompanyDbContext _context;

    public UnitOfWork(CompanyDbContext context)
    {
        _context = context;

        DepartmentRepository = new DepartmentRepository(context);
        EmployeeRepository = new EmployeeRepository(context);
    }

    public IDepartmentRepository DepartmentRepository { get; set; }

    public IEmployeeRepository EmployeeRepository { get; set; }

    public int Commit()
    {
        return _context.SaveChanges();
    }
}
