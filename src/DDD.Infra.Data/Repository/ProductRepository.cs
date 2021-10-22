using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;

namespace DDD.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Product GetByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<Product> GetByIds(List<Guid> productIds)
        {
            return _context.Products.Where(p => productIds.Contains(p.Id)).ToList();
        }
    }
}
