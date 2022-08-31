using System.Linq.Expressions;

namespace Domain.Specifications.Common;

public class AnonymousSpecification<T> : ExpressionSpecification<T>
    where T : class
{
    public AnonymousSpecification(Expression<Func<T, bool>> expr)
    {
        Where(expr);
    }
}