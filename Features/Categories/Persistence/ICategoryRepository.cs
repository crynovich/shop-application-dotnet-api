using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApplication.Features.Categories.Domain;

namespace ProductsApplication.Features.Categories.Persistence
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id);
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
