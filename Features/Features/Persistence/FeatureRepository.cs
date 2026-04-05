using Microsoft.EntityFrameworkCore;
using ProductsApplication.Data;
using ProductsApplication.Features.Features.Domain;

namespace ProductsApplication.Features.Features.Persistence
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly ProductsDbContext _db;

        public FeatureRepository(ProductsDbContext db) => _db = db;

        public async Task AddAsync(Feature feature)
        {
            await _db.Features.AddAsync(feature!);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Features.FindAsync(id);
            if (entity is null)
                return;
            _db.Features.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Feature?> GetByIdAsync(int id)
        {
            return await _db.Features.Include(f => f.Products).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Feature>> ListAsync()
        {
            return await _db.Features.Include(f => f.Products).ToListAsync();
        }

        public async Task UpdateAsync(Feature feature)
        {
            _db.Features.Update(feature!);
            await _db.SaveChangesAsync();
        }
    }
}
