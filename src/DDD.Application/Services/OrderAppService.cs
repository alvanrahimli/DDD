using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands.Order;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IEventStoreRepository _eventStoreRepository;

        public OrderAppService(IOrderRepository orderRepository,
            IMapper mapper,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {

        }

        public void Add(OrderDto newOrder)
        {
            _bus.SendCommand(new AddNewOrderCommand(newOrder.CustomerId, newOrder.OrderItems));
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new DeleteOrderCommand {OrderId = id});
        }

        public List<OrderViewModel> GetOrders(int skip, int take)
        {
            var orders = _orderRepository.GetAllPaginated(skip, take);
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
    }
}
