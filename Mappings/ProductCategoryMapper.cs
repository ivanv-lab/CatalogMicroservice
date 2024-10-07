using CatalogMicroservice.DTO;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class ProductCategoryMapper
    {
        public ProductCategory Map(ProductCategoryDto dto)
        {
            return new ProductCategory
            {
                Name = dto.Name
            };
        }
        public ProductCategoryDto Map(ProductCategory model)
        {
            return new ProductCategoryDto
            {
                Name = model.Name
            };
        }
        public IEnumerable<ProductCategoryDto> MapList(
            IEnumerable<ProductCategory> models)
        {
            List<ProductCategoryDto> result = new List<ProductCategoryDto>();
            foreach (var model in models)
            {
                result.Add(Map(model));
            }
            return result;
        }
    }
}
