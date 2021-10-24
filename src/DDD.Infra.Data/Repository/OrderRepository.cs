using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetAllPaginated(int skip, int take)
        {
            return _context.Orders.AsNoTracking()
                .Include(o => o.OrderItems).ThenInclude(item => item.Product)
                .OrderBy(o => o.CreatedAt)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}
