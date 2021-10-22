using DDD.Domain.Commands;

namespace DDD.Domain.Validations.Product
{
    public class AddProductValidation : ProductValidation<ProductCommand>
    {
        public AddProductValidation()
        {
            ValidateName();
            ValidatePrice();
        }
    }
}
