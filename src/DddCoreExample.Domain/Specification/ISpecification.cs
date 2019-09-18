using System;
using System.Linq.Expressions;

namespace DddCoreExample.Domain.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}