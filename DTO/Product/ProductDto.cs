namespace CatalogMicroservice.DTO
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name {  get; set; }
        public int Count {  get; set; }
        public decimal Price {  get; set; }
        public virtual ProductCategoryDto? Category { get; set; }
    }
}
