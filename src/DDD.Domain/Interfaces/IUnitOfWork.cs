using System;

namespace DDD.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        public IProductRepository ProductRepository { get; }
    }
}
