namespace CatalogMicroservice.Models
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
