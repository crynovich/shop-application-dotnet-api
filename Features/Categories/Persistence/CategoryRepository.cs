using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApplication.Data;
using ProductsApplication.Features.Categories.Domain;

namespace ProductsApplication.Features.Categories.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsDbContext _db;
        public CategoryRepository(ProductsDbContext db) => _db = db;

        public async Task AddAsync(Category category)
        {
            await _db.Categories.AddAsync(category!);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Categories.FindAsync(id);
            if (entity is null) return;
            _db.Categories.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _db.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _db.Categories
                .Include(c => c.Products)
                .ToListAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _db.Categories.Update(category!);
            await _db.SaveChangesAsync();
        }
    }
}
