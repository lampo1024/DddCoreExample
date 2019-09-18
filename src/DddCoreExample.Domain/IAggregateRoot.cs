using System;

namespace DddCoreExample.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
