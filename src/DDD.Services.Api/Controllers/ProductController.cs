using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IProductAppService _productAppService;

        public ProductController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IProductAppService productAppService) : base(notifications, mediator)
        {
            _mediator = mediator;
            _productAppService = productAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("products")]
        public IActionResult AddProduct([FromBody] ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(product);
            }

            _productAppService.Add(product);
            return Response(product);
        }
    }
}
