namespace CatalogMicroservice.Models
{
    public class ProductProperty
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductPropertyValue>? ProductPropertyValues { get; set; }
    }
}
