using Microsoft.EntityFrameworkCore;

namespace ProductsApplication.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options) { }

        // Define DbSets here, e.g.
        // public DbSet<Product> Products { get; set; }
    }
}
