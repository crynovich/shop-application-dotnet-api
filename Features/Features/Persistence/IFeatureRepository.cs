using ProductsApplication.Features.Features.Domain;

namespace ProductsApplication.Features.Features.Persistence
{
    public interface IFeatureRepository
    {
        Task<Feature?> GetByIdAsync(int id);
        Task<IEnumerable<Feature>> ListAsync();
        Task AddAsync(Feature feature);
        Task UpdateAsync(Feature feature);
        Task DeleteAsync(int id);
    }
}
