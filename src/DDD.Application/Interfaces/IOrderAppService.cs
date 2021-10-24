using System;
using System.Collections.Generic;
using DDD.Application.ViewModels;
using DDD.Domain.Commands.Order;

namespace DDD.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void Add(OrderViewModel orderViewModel);
        void Delete(Guid id);
    }
}
