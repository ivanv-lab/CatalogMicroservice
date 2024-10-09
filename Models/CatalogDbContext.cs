using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Models
{
    public class CatalogDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public CatalogDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> Properties { get; set; }
        public DbSet<ProductPropertyValue> Values { get; set; }
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

            modelBuilder.Entity<ProductPropertyValue>()
                .HasOne(ppv => ppv.Product)
                .WithMany(p => p.ProductPropertyValues)
                .HasForeignKey(ppv => ppv.ProductId);

            modelBuilder.Entity<ProductPropertyValue>()
                .HasOne(ppv=>ppv.Property)
                .WithMany(p=>p.ProductPropertyValues)
                .HasForeignKey(ppv=>ppv.PropertyId);

            modelBuilder.Entity<ProductPropertyValue>()
                .HasKey(ppv => new { ppv.ProductId, ppv.PropertyId });
        }
    }
}
