using DDD.Domain.Validations.Product;

namespace DDD.Domain.Commands.Product
{
    public class AddNewProductCommand : ProductCommand
    {
        public AddNewProductCommand(string name, decimal price) : base(name, price)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
