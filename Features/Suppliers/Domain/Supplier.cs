using System.Collections.Generic;

namespace ProductsApplication.Features.Suppliers.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactInfo { get; set; }

        public ICollection<Products.Domain.Product>? Products { get; set; }
    }
}
