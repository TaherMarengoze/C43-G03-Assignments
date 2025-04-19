using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class GenericRepository<TEntity, TKey>(StoreDbContext context)
    : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    public async Task<TEntity?> GetAsync(TKey id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
    
    public async Task<TEntity?> GetAsync(Specification<TEntity> specification)
    {
        return await GetBaseQuey(specification).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracked = false)
    {
        if (tracked)
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Specification<TEntity> specification)
    {
        return await GetBaseQuey(specification).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    private IQueryable<TEntity> GetBaseQuey(Specification<TEntity> specification)
    {
        return SpecificationEvaluator.GetQuery(context.Set<TEntity>(), specification);
    }
}
