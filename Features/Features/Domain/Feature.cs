using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Features.Domain
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
