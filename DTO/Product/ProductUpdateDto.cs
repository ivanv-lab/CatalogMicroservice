namespace CatalogMicroservice.DTO
{
    public class ProductUpdateDto
    {
        public long Id {  get; set; }
        public string Name { get; set; }
        public long ProductCategoryId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
