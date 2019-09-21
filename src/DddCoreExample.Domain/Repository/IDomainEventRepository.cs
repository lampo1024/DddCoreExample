using System.Collections.Generic;

namespace DddCoreExample.Domain.Repository
{
    public interface IDomainEventRepository
    {
        void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
        IEnumerable<DomainEventRecord> FindAll();
    }
}
