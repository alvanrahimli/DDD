using DDD.Domain.Interfaces;
using DDD.Infra.Data.Context;
using DDD.Infra.Data.Repository;

namespace DDD.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => new ProductRepository(_context);

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
