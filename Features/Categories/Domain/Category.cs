using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Categories.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
