using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;

namespace DDD.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
