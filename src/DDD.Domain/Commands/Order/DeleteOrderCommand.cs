using System;
using DDD.Domain.Core.Commands;

namespace DDD.Domain.Commands.Order
{
    public class DeleteOrderCommand : Command
    {
        public Guid OrderId { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
