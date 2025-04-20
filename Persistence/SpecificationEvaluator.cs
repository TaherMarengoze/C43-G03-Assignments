using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public static class SpecificationEvaluator
{
    public static IQueryable<T> GetQuery<T>(IQueryable<T> baseQuery, Specification<T> specifications)
        where T : class
    {
        var query = baseQuery;

        if (specifications is not null)
        {
            query = query.Where(specifications.Criteria);
        }

        query = specifications.Includes.Aggregate(query,
            (currentQry, includeExpr) => currentQry.Include(includeExpr));

        if (specifications.OrderBy is not null)
        {
            query = query.OrderBy(specifications.OrderBy);
        }
        else if (specifications.OrderByDesc is not null)
        {
            query = query.OrderByDescending(specifications.OrderByDesc);
        }

        if (specifications.IsPaginated)
        {
            query = query.Skip(specifications.Skip).Take(specifications.Take);
        }

        return query;
    }
}
