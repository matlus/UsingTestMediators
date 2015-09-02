using System.Collections.Generic;

namespace OrderSystem.DomainLayer.Models
{
    public sealed class ProductInStock
    {
        private readonly long id;
        public long Id { get { return id; } }

        private readonly string name;
        public string Name { get { return name; } }

        private readonly int quantity;
        public int Quantity { get { return quantity; } }

        public ProductInStock(long id, string name, int quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
        }
    }
}
