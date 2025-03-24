using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repo.Interfaces;

namespace Company.Repo.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    private readonly CompanyDbContext _context;

    public DepartmentRepository(CompanyDbContext context) : base(context)
    {
        _context = context;
    }
}
