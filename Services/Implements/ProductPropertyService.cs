using CatalogMicroservice.DTO;
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

        public async Task<IEnumerable<ProductPropertyDto>> GetAll()
        {
            var props=await _repository.GetAll();
            return _mapper.MapList(props);
        }

        public async Task<ProductPropertyDto> Create(ProductPropertyDto productPropertyDto)
        {
            var prop=_mapper.Map(productPropertyDto);
            await _repository.Add(prop);
            return _mapper.Map(prop);
        }

        public async Task<ProductPropertyDto> Update(long id, ProductPropertyDto productPropertyDto)
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

        public Task<IEnumerable<ProductPropertyDto>> Search(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
