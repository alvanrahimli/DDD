using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Product;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IEventStoreRepository _eventStoreRepository;

        public ProductAppService(IProductRepository productRepository,
            IMapper mapper,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _bus = bus;
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

        public IQueryable<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;
        }

        public ProductViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductViewModel updatedProduct)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(updatedProduct);
            _bus.SendCommand(updateCommand);
        }
    }
}
