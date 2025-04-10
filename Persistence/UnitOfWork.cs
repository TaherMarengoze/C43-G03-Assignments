using System.Collections.Concurrent;
using Domain.Contracts;
using Domain.Entities;
using Persistence.Data;
using Persistence.Repositories;

namespace Persistence;

public class UnitOfWork(StoreDbContext context) : IUnitOfWork
{
    //private Dictionary<string, object> repositories;
    private ConcurrentDictionary<string, object>? repositories;

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : BaseEntity<TKey>
    {
        repositories ??= new ConcurrentDictionary<string, object>();

        return (IGenericRepository<TEntity, TKey>)
            repositories.GetOrAdd(typeof(TEntity).Name,
                _ => new GenericRepository<TEntity, TKey>(context));

        //repositories ??= new Dictionary<string, object>();

        //var key = typeof(TEntity).Name;

        //if (!repositories.ContainsKey(key))
        //{
        //    var repoType = typeof(GenericRepository<,>);

        //    var instance = Activator.CreateInstance(
        //        repoType.MakeGenericType(typeof(TEntity), typeof(TKey)),
        //        context
        //    );

        //    repositories.Add(key, instance!);
        //}

        //return (IGenericRepository<TEntity, TKey>)repositories[key];
    }
}
