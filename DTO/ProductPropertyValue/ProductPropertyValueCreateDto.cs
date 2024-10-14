namespace CatalogMicroservice.DTO.ProductPropertyValue
{
    public class ProductPropertyValueCreateDto
    {
        public long ProductId { get; set; }
        public long PropertyId { get; set; }
        public string Value { get; set; }
    }
}
