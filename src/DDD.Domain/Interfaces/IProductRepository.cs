using System;
using System.Collections.Generic;
using DDD.Domain.Models;

namespace DDD.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);
        IEnumerable<Product> GetByIds(List<Guid> productIds);
    }
}
