namespace CatalogMicroservice.Models
{
    public class Property
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryProperty> Categories { get; set; }
        public ICollection<ProductProperty> Products { get; set; }
    }
}
