using System;

namespace DddCoreExample.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
