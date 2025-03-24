using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repo.Interfaces;

namespace Company.Repo.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : ModelMetadata
{
    private readonly CompanyDbContext _context;

    public BaseRepository(CompanyDbContext context)
    {
        _context = context;
    }

    public T? GetById(int id) => _context.Set<T>().Find(id);

    public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

    public void Add(T entity) => _context.Set<T>().Add(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}
