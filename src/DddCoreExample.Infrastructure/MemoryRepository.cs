using System;
using System.Collections.Generic;
using System.Linq;
using DddCoreExample.Domain;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Infrastructure
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        protected static List<TEntity> Entities = new List<TEntity>();
        public TEntity FindById(Guid id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public TEntity FindOne(ISpecification<TEntity> spec)
        {
            return Entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            return Entities.Where(spec.IsSatisfiedBy);
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}
