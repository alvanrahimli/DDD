using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;

namespace DDD.Infra.Data.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool Exists(Guid orderId, Guid productId)
        {
            return _context.OrderItems.Any(oi => oi.OrderId == orderId && oi.ProductId == productId);
        }

        public void AddRange(List<OrderItem> obj)
        {
            _context.OrderItems.AddRange(obj);
        }
    }
}
