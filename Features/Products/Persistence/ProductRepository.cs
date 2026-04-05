using Microsoft.EntityFrameworkCore;
using ProductsApplication.Data;
using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Products.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _db;

        public ProductRepository(ProductsDbContext db) => _db = db;

        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product!);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Products.FindAsync(id);
            if (entity is null)
                return;
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _db.Products.Include(p => p.Supplier).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Products.Update(product!);
            await _db.SaveChangesAsync();
        }
    }
}
