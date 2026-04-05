using System.Collections.Generic;

namespace ProductsApplication.Features.Products.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int? SupplierId { get; set; }
        public Suppliers.Domain.Supplier? Supplier { get; set; }
    }
}
