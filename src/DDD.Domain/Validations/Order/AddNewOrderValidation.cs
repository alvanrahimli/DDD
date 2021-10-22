using DDD.Domain.Commands.Order;

namespace DDD.Domain.Validations.Order
{
    public class AddNewOrderValidation : OrderValidation<OrderCommand>
    {
        public AddNewOrderValidation()
        {
            ValidateIdCount();
        }
    }
}
