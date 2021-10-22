using System;
using System.Collections.Generic;
using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;

        public ProductAppService(IMapper mapper,
            ICustomerRepository customerRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _customerRepository = customerRepository;
            _eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(ProductViewModel newProduct)
        {
            var productAddCommand = _mapper.Map<AddNewProductCommand>(newProduct);
            _bus.SendCommand(productAddCommand);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
