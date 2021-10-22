using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<AddNewProductCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public ProductCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }


        public async Task<bool> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var existingProduct = _uow.ProductRepository.GetByName(request.Name.Trim());
            if (existingProduct != null)
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Product with same name already exists"));
                return await Task.FromResult(false);
            }

            var product = new Product(request.Name, request.Price);
            _uow.ProductRepository.Add(product);

            if (!Commit())
            {
                await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Could not save product data"));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
