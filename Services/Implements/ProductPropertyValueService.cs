using CatalogMicroservice.DTO;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class ProductPropertyValueService
        : IProductPropertyValueService
    {
        private readonly IProductPropertyValueRepository _repository;
        private readonly ProductPropertyValueMapper _mapper;
        public ProductPropertyValueService
            (IProductPropertyValueRepository repository,
            ProductPropertyValueMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Create(ProductPropertyValueDto productPropertyValueDto)
        {
            var propVal=_mapper.Map(productPropertyValueDto);
            await _repository.Add(propVal);
        }

        public async Task Delete(long id)
        {
            await _repository.DeleteById(id);
        }

        public async Task<IEnumerable<ProductPropertyValueDto>> GetAll()
        {
            var propVals=await _repository.GetAll();
            return _mapper.MapList(propVals);
        }

        public async Task<IEnumerable<ProductPropertyValueDto>> GetByProductId(long productId)
        {
            var propValues= await _repository.GetByProductId(productId);
            return _mapper.MapList(propValues);
        }

        public Task<IEnumerable<ProductPropertyValueDto>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task Update(long id, ProductPropertyValueDto productPropertyValueDto)
        {
            var propVal = _mapper.Map(productPropertyValueDto);
            await _repository.Update(id, propVal);
        }
    }
}
