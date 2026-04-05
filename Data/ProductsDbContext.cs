using Microsoft.EntityFrameworkCore;
using ProductsApplication.Features.Categories.Domain;
using ProductsApplication.Features.Features.Domain;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Suppliers.Domain;

namespace ProductsApplication.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Feature> Features { get; set; } = null!;

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
                b.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Supplier>(b =>
            {
                b.HasKey(s => s.Id);
                b.Property(s => s.Name).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(s => s.Id);
                c.Property(s => s.Name).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Feature>(f =>
            {
                f.HasKey(x => x.Id);
                f.Property(x => x.Name).IsRequired().HasMaxLength(200);
            });

            // implicit many-to-many between Product and Feature
            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Features)
                .WithMany(f => f.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductFeature",
                    j =>
                        j.HasOne<Feature>()
                            .WithMany()
                            .HasForeignKey("FeatureId")
                            .HasConstraintName("fk_product_feature_feature_id"),
                    j =>
                        j.HasOne<Product>()
                            .WithMany()
                            .HasForeignKey("ProductId")
                            .HasConstraintName("fk_product_feature_product_id"),
                    j =>
                    {
                        // composite primary key and unique constraint
                        j.HasKey("ProductId", "FeatureId");
                        j.HasIndex(new[] { "FeatureId", "ProductId" })
                            .IsUnique()
                            .HasDatabaseName("ux_product_feature_feature_product");
                        // optional: control table name/column names
                        j.ToTable("ProductFeature");
                    }
                );
        }
    }
}
