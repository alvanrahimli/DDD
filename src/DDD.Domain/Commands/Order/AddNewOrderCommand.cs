using System;
using System.Collections.Generic;
using DDD.Domain.Validations.Order;

namespace DDD.Domain.Commands.Order
{
    public class AddNewOrderCommand : OrderCommand
    {
        public Guid CustomerId { get; }

        public AddNewOrderCommand(Guid customerId, List<OrderItemDto> orderItems)
        {
            CustomerId = customerId;
            OrderItems = orderItems;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
