using System.Linq.Expressions;

namespace Domain.Contracts;

public abstract class Specification<T> where T : class
{
    protected Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = [];

    public Expression<Func<T,object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDesc { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> expression)
    {
        Includes.Add(expression);
    }

    protected void SetOrderBy(Expression<Func<T, object>> orderByExpr)
    {
        OrderBy = orderByExpr;
    }

    protected void SetOrderByDesc(Expression<Func<T, object>> orderByExpr)
    {
        OrderByDesc = orderByExpr;
    }
}
