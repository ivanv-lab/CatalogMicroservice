using CatalogMicroservice.DTO;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class ProductPropertyValueMapper
    {
        public ProductPropertyValue Map
            (ProductPropertyValueDto dto)
        {
            return new ProductPropertyValue
            {
                Value = dto.Value
            };
        }
        public ProductPropertyValueDto Map
            (ProductPropertyValue model)
        {
            return new ProductPropertyValueDto
            {
                Value = model.Value
            };
        }
        public IEnumerable<ProductPropertyValueDto> MapList(
            IEnumerable<ProductPropertyValue> models)
        {
            List<ProductPropertyValueDto> result=new List<ProductPropertyValueDto>();
            foreach (var model in models)
            {
                result.Add(Map(model));
            }
            return result;
        }
    }
}
