using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Products.Persistence
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByIdWithFeaturesAsync(int id);
        Task<IEnumerable<Product>> GetBySupplierIdAsync(int supplierId);
        Task<IEnumerable<Product>> FindByNameAsync(string name);
        Task<IEnumerable<Product>> GetPagedAsync(int page, int pageSize);
        Task AddRangeAsync(IEnumerable<Product> products);
        Task<int> GetCountAsync();
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
