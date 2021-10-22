using DDD.Domain.Commands;
using FluentValidation;

namespace DDD.Domain.Validations.Product
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required")
                .Length(2, 150).WithMessage("Name must be 2 to 150 symbol");
        }

        protected void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price should be greater than or equal to 0");
        }
    }
}
