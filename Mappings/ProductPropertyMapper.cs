using CatalogMicroservice.DTO;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class ProductPropertyMapper
    {
        public ProductProperty Map(ProductPropertyDto dto)
        {
            return new ProductProperty
            {
                Name = dto.Name
            };
        }
        public ProductPropertyDto Map(ProductProperty model)
        {
            return new ProductPropertyDto
            {
                Name = model.Name
            };
        }
        public IEnumerable<ProductPropertyDto> MapList(IEnumerable<ProductProperty> models)
        {
            List<ProductPropertyDto> result= new List<ProductPropertyDto>();
            foreach(var model in models)
            {
                result.Add(Map(model));
            }
            return result;
        }
    }
}
