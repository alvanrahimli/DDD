using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Commands.Order;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DDD.Domain.CommandHandlers
{
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<AddNewOrderCommand, bool>,
        IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public OrderCommandHandler(IUnitOfWork uow,
            IMediatorHandler bus,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IOrderItemRepository orderItemRepository,
            IHttpContextAccessor httpContextAccessor,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _uow = uow;
            _bus = bus;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
            _httpContextAccessor = httpContextAccessor;
            _notifications = notifications;
        }

        public async Task<bool> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Invalid Model State"));
                return await Task.FromResult(false);
            }

            var productIds = request.OrderItems.Select(oi => oi.ProductId).ToList();
            var products = _productRepository.GetByIds(productIds).ToList();

            if (products.Count != productIds.Count)
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType,
                    "Found product count did not match with requested products"));
                return await Task.FromResult(false);
            }

            var orderItems = request.OrderItems.Select(oi => new OrderItem(oi.ProductId, oi.Count)).ToList();
            var totalPrice = products.Sum(p => p.Price * orderItems.FirstOrDefault(oi => oi.ProductId == p.Id)?.Count);

            var order = new Order(totalPrice ?? 0)
            {
                CustomerId = request.CustomerId,
            };
            _orderRepository.Add(order);

            orderItems.ForEach(oi => oi.OrderId = order.Id);
            _orderItemRepository.AddRange(orderItems);

            if (!Commit())
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Could not save order data"));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.GetById(request.OrderId);
            if (order == null)
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Could not find order"));
                return await Task.FromResult(false);
            }

            _orderRepository.Remove(order.Id);

            if (!Commit())
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Could not save order data"));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
