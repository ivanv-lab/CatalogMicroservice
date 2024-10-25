using CatalogMicroservice.DTO.CategoryProperty;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class CategoryPropertyMapper
    {
        public CategoryProperty Map(CategoryPropertyCreateDto dto)
        {
            return new CategoryProperty
            {
                CategoryId = dto.CategoryId,
                PropertyId = dto.PropertyId
            };
        }
    }
}
