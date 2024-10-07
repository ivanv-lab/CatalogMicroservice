using CatalogMicroservice.DTO;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ProductMapper _mapper;
        public ProductService(IProductRepository repository, ProductMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(ProductDto productDto)
        {
            var prod=_mapper.Map(productDto);
            await _repository.Add(prod);
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

        public Task<IEnumerable<ProductDto>> Filters()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var prods=await _repository.GetAll();
            return _mapper.MapList(prods);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategory(long categoryId)
        {
            var prods=await _repository.GetByCategory(categoryId);
            return _mapper.MapList(prods);
        }

        public async Task<ProductDto> GetById(long id)
        {
            var prod=await _repository.GetById(id);
            return _mapper.Map(prod);
        }

        public Task<IEnumerable<ProductDto>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task Update(long id, ProductDto productDto)
        {
            var prod = _mapper.Map(productDto);
            await _repository.Update(id, prod);
        }
    }
}
