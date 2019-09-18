using System;
using System.Collections.Generic;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);
        TEntity FindOne(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
