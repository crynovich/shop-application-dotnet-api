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
            return await _db
                .Products.Include(p => p.Supplier)
                .Include(p => p.Category)
                .Include(p => p.Features)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByIdWithFeaturesAsync(int id)
        {
            return await _db.Products.Include(p => p.Features).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetBySupplierIdAsync(int supplierId)
        {
            return await _db.Products.Where(p => p.SupplierId == supplierId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindByNameAsync(string name)
        {
            return await _db.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetPagedAsync(int page, int pageSize)
        {
            return await _db.Products.Skip(pageSize * page).Take(pageSize).ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Product> products)
        {
            await _db.Products.AddRangeAsync(products);
            await _db.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _db.Products.CountAsync();
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _db.Products.Include(p => p.Supplier).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
