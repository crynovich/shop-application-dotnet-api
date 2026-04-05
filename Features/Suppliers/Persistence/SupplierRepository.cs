using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApplication.Data;
using ProductsApplication.Features.Suppliers.Domain;

namespace ProductsApplication.Features.Suppliers.Persistence
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ProductsDbContext _db;

        public SupplierRepository(ProductsDbContext db) => _db = db;

        public async Task AddAsync(Supplier supplier)
        {
            await _db.Suppliers.AddAsync(supplier!);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Suppliers.FindAsync(id);
            if (entity is null)
                return;
            _db.Suppliers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _db
                .Suppliers.Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _db.Suppliers.Include(s => s.Products).ToListAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _db.Suppliers.Update(supplier!);
            await _db.SaveChangesAsync();
        }
    }
}
