using System.Linq.Expressions;
using _Expression = System.Linq.Expressions.Expression;

namespace Domain.Specifications.Common.Operators;

public class NotSpecification<T> : ExpressionSpecification<T>
    where T : class
{
    public NotSpecification(Expression<Func<T, bool>> spec)
    {
        var right = spec;
        var param = _Expression.Parameter(typeof(T), right.Parameters.FirstOrDefault()?.Name);
        var body = _Expression.Not(_Expression.Invoke(right, param));
        Where(_Expression.Lambda<Func<T, bool>>(body, param));
    }
}