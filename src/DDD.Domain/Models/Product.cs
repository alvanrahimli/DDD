using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Product : EntityAudit
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
