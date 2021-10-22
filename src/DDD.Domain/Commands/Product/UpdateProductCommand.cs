using System;
using DDD.Domain.Validations.Product;

namespace DDD.Domain.Commands.Product
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name, decimal price) : base(name, price)
        {
            Id = id;
        }

        public Guid Id { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
