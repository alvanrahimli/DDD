using DDD.Domain.Core.Commands;
using DDD.Domain.Validations.Product;
using MediatR;

namespace DDD.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public ProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
