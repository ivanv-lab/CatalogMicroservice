namespace CatalogMicroservice.Models
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Product>? Products { get; set; }
        public ICollection<CategoryProperty> Properties { get; set; }
    }
}
