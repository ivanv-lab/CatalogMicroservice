using CatalogMicroservice.DTO.Property;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IPropertyService
    {
        public Task<PropertyDto> GetById(long id);
        public Task<IEnumerable<PropertyDto>> GetAll();
        public Task<PropertyDto> Create(PropertyCreateDto propertyCreateDto);
        public Task<PropertyDto> Update(long id, PropertyUpdateDto propertyUpdateDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<PropertyDto>> Search
            (string? searchString);
        public Task<int> GetCount();
    }
}
