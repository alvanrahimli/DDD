using DDD.Domain.Models;

namespace DDD.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);
    }
}
