using CatalogMicroservice.DTO;
using CatalogMicroservice.DTO.ProductCategory;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class ProductCategoryMapper
    {
        public ProductCategory Map(ProductCategoryDto dto)
        {
            return new ProductCategory
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        public ProductCategoryDto Map(ProductCategory model)
        {
            return new ProductCategoryDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public ProductCategory Map(ProductCategoryUpdateDto dto)
        {
            return new ProductCategory
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        public ProductCategory Map(ProductCategoryCreateDto dto)
        {
            return new ProductCategory
            {
                Name = dto.Name
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
