using System;
using System.Collections.Generic;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands.Order;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IMediatorHandler _mediator;

        public OrderController(INotificationHandler<DomainNotification> notifications,
            IOrderAppService orderAppService,
            IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _orderAppService = orderAppService;
            _mediator = mediator;
        }

        [HttpPost("order")]
        [Authorize(Policy = "CanWriteOrderData")]
        public IActionResult AddOrder(OrderDto newOrder)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(newOrder);
            }

            _orderAppService.Add(newOrder);
            return Response(newOrder);
        }

        [HttpDelete("order/{id:guid}")]
        public IActionResult DeleteOrder(Guid id)
        {
            _orderAppService.Delete(id);
            return Response();
        }

        [HttpGet]
        public IActionResult GetOrders(int skip, int take)
        {
            var orders = _orderAppService.GetOrders(skip, take);
            return Response(orders);
        }
    }
}
