using CatalogMicroservice.DTO;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        private readonly ProductCategoryMapper _mapper;
        public ProductCategoryService(IProductCategoryRepository repository,
            ProductCategoryMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Create(ProductCategoryDto productCategoryDto)
        {
            var cat=_mapper.Map(productCategoryDto);
            await _repository.Add(cat);
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAll(long id)
        {
            var cats = await _repository.GetAll();
            return _mapper.MapList(cats);
        }

        public async Task<ProductCategoryDto> GetById(long id)
        {
            var cat=await _repository.GetById(id);
            return _mapper.Map(cat);
        }

        public Task<IEnumerable<ProductCategoryDto>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task Update(long id, ProductCategoryDto productCategoryDto)
        {
            var cat = _mapper.Map(productCategoryDto);
            await _repository.Update(id, cat);
        }
    }
}
