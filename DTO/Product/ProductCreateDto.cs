namespace CatalogMicroservice.DTO
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public long ProductCategoryId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
