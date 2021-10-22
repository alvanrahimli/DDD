using System;
using System.Collections.Generic;
using DDD.Domain.Core.Commands;
using MediatR;

namespace DDD.Domain.Commands.Order
{
    public abstract class OrderCommand : Command
    {
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
