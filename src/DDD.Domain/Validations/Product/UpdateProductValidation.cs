using DDD.Domain.Commands.Product;

namespace DDD.Domain.Validations.Product
{
    public class UpdateProductValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateName();
            ValidatePrice();
        }
    }
}
