namespace CatalogMicroservice.Models
{
    public class CategoryProperty
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long PropertyId {  get; set; }
        public ProductCategory? Category { get; set; }
        public Property? Property { get; set; }
    }
}
