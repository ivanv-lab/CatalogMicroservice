using CatalogMicroservice.DTO.Property;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class PropertyService:IPropertyService
    {
        private readonly IPropertyRepository _repository;
        private readonly PropertyMapper _mapper;
        public PropertyService(IPropertyRepository repository, 
            PropertyMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Create(PropertyCreateDto propertyCreateDto)
        {
            var prop=_mapper.Map(propertyCreateDto);
            await _repository.Add(prop);
            return _mapper.Map(prop);
        }

        public async Task<bool> Delete(long id)
        {
            var prop=await _repository.GetById(id);
            if (prop != null)
            {
                await _repository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<PropertyDto>> GetAll()
        {
           var props=await _repository.GetAll();
            return _mapper.MapList(props);
        }

        public async Task<PropertyDto> GetById(long id)
        {
            var prop = await _repository.GetById(id);
            return _mapper.Map(prop);
        }

        public async Task<int> GetCount()
        {
            return await _repository.GetCount();
        }

        public async Task<IEnumerable<PropertyDto>> Search(string? searchString)
        {
            var props = await _repository.GetAll();
            if (!string.IsNullOrEmpty(searchString)
                || searchString==" ")
            {
                searchString=searchString.ToLower();
                props=props.Where(
                    p=>p.Id.ToString().Contains(searchString)
                    || p.Name.ToLower().Contains(searchString));
            }
            return _mapper.MapList(props);
        }
        public async Task<PropertyDto> Update(long id, PropertyUpdateDto propertyUpdateDto)
        {
            var prop=_mapper.Map(propertyUpdateDto);
            await _repository.Update(id, prop);
            return _mapper.Map(prop);
        }
    }
}
