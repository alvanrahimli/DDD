using DDD.Domain.Commands.Order;
using DDD.Domain.Core.Commands;
using FluentValidation;

namespace DDD.Domain.Validations.Order
{
    public class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        public void ValidateIdCount()
        {
            RuleFor(o => o.OrderItems)
                .Must(oi => oi.Count > 0).WithMessage("Not enough product is selected");
        }
    }
}
