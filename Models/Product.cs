namespace CatalogMicroservice.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProductCategoryId {  get; set; }
        public int Count {  get; set; }
        public decimal Price {  get; set; }
        public bool IsDeleted { get; set; } = false;
        public ProductCategory? Category { get; set; }
        public ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
