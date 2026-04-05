using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Suppliers.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactInfo { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
