namespace ProductsApplication.Features.Products.Domain
{
    public class ProductFeature
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public string? Value { get; set; }
    }
}
