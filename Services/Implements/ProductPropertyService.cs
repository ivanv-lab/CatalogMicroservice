using CatalogMicroservice.DTO;
using CatalogMicroservice.DTO.ProductProperty;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class ProductPropertyService:
        IProductPropertyService
    {
        private readonly IProductPropertyRepository _repository;
        private readonly ProductPropertyMapper _mapper;
        public ProductPropertyService(IProductPropertyRepository repository,
            ProductPropertyMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductPropertyDto> GetById(long id)
        {
            var prop= await _repository.GetById(id);
            return _mapper.Map(prop);
        }
        public async Task<IEnumerable<ProductPropertyDto>> GetAll()
        {
            var props=await _repository.GetAll();
            return _mapper.MapList(props);
        }

        public async Task<ProductPropertyDto> Create(ProductPropertyCreateDto productPropertyDto)
        {
            var prop=_mapper.Map(productPropertyDto);
            await _repository.Add(prop);
            return _mapper.Map(prop);
        }

        public async Task<ProductPropertyDto> Update(long id, ProductPropertyUpdateDto productPropertyDto)
        {
            var prop = _mapper.Map(productPropertyDto);
            await _repository.Update(id, prop);
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

        public async Task<IEnumerable<ProductPropertyDto>> Search(string? searchString)
        {
            var properties = await _repository.GetAll();
            if(!string.IsNullOrEmpty(searchString)
                || searchString==" ")
            {
                searchString = searchString.ToLower();
                properties=properties.Where(
                    p=>p.Id.ToString().Contains(searchString)
                    || p.Name.ToLower().Contains(searchString));
            }
            return _mapper.MapList(properties);
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }
    }
}
