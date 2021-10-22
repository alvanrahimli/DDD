using System;
using System.Collections.Generic;
using DDD.Domain.Models;

namespace DDD.Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        bool Exists(Guid orderId, Guid productId);
        void AddRange(List<OrderItem> obj);
    }
}
