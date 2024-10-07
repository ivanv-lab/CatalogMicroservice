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

        public async Task Create(ProductPropertyDto productPropertyDto)
        {
            var prop=_mapper.Map(productPropertyDto);
            await _repository.Add(prop);
        }

        public async Task Update(long id, ProductPropertyDto productPropertyDto)
        {
            var prop = _mapper.Map(productPropertyDto);
            await _repository.Update(id, prop);
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPropertyDto>> Search(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
