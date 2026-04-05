using Microsoft.EntityFrameworkCore;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Suppliers.Domain;

namespace ProductsApplication.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options) { }

        // Define DbSets here, e.g.
        // public DbSet<Product> Products { get; set; }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // todo: make this nicer, now everything is in a single class
            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).IsRequired().HasMaxLength(200);
                b.Property(p => p.Price).HasPrecision(18, 2);
                b.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Supplier>(b =>
            {
                b.HasKey(s => s.Id);
                b.Property(s => s.Name).IsRequired().HasMaxLength(200);
            });
        }
    }
}
