using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Models
{
    public class CatalogDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CatalogDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<CategoryProperty> CategoriesProperties { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString
                ("SQLServerCatalogBase"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            modelBuilder.Entity<CategoryProperty>()
                .HasKey(cp =>cp.Id);

            modelBuilder.Entity<CategoryProperty>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.Properties)
                .HasForeignKey(cp => cp.CategoryId);

            modelBuilder.Entity<CategoryProperty>()
                .HasOne(cp => cp.Property)
                .WithMany(c => c.Categories)
                .HasForeignKey(cp => cp.PropertyId);

            modelBuilder.Entity<ProductProperty>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.Properties)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<ProductProperty>()
                .HasOne(pp => pp.Property)
                .WithMany(p=>p.Products)
                .HasForeignKey(pp => pp.PropertyId);
        }
    }
}
