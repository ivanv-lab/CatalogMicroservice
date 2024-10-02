namespace CatalogMicroservice.Models
{
    public class ProductPropertyValue
    { 
        public long ProductId {  get; set; }
        public long PropertyId {  get; set; }
        public string Value {  get; set; }
        public Product? Product { get; set; }
        public ProductProperty? Property { get; set; }
        
    }
}
