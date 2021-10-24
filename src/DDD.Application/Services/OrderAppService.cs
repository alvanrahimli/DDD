using System;
using System.Collections.Generic;
using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands.Order;
using DDD.Domain.Core.Bus;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IEventStoreRepository _eventStoreRepository;

        public OrderAppService(IMapper mapper,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {

        }

        public void Add(OrderViewModel orderViewModel)
        {
            _bus.SendCommand(new AddNewOrderCommand(orderViewModel.CustomerId, orderViewModel.OrderItems));
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
