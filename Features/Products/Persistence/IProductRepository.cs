using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Products.Persistence
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
