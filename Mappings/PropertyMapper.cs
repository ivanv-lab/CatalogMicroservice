using CatalogMicroservice.DTO.Property;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class PropertyMapper
    {
        public Property Map(PropertyDto dto)
        {
            return new Property
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        public PropertyDto Map(Property model)
        {
            return new PropertyDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public Property Map(PropertyCreateDto dto)
        {
            return new Property
            {
                Name = dto.Name
            };
        }
        public Property Map(PropertyUpdateDto dto)
        {
            return new Property
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        public IEnumerable<PropertyDto> MapList
            (IEnumerable<Property> models)
        {
            List<PropertyDto> result = new List<PropertyDto>();
            foreach (var model in models)
            {
                result.Add(Map(model));
            }
            return result;
        }
    }
}
