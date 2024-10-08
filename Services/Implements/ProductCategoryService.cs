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

        public async Task<ProductCategoryDto> Create(ProductCategoryCreateDto productCategoryDto)
        {
            var cat=_mapper.Map(productCategoryDto);
            await _repository.Add(cat);
            return _mapper.Map(cat);
        }

        public async Task<bool> Delete(long id)
        {
            var cat = await _repository.GetById(id);
            if (cat != null)
            {
                await _repository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAll()
        {
            var cats = await _repository.GetAll();
            return _mapper.MapList(cats);
        }

        public async Task<ProductCategoryDto> GetById(long id)
        {
            var cat=await _repository.GetById(id);
            return _mapper.Map(cat);
        }

        public async Task<int> GetCount()
        {
            return await _repository.GetCount();
        }

        public async Task<IEnumerable<ProductCategoryDto>> Search(string searchString)
        {
            var categories=await _repository.GetAll();
            if(!string.IsNullOrEmpty(searchString)
                || searchString==" ")
            {
                searchString=searchString.ToLower();
                categories = categories.Where(
                    c => c.Name.ToLower()
                    .Contains(searchString)
                    || c.Id.ToString().Contains(searchString));
            }
            
            return _mapper.MapList(categories);
        }

        public async Task<ProductCategoryDto> Update(long id, ProductCategoryCreateDto productCategoryDto)
        {
            var cat = _mapper.Map(productCategoryDto);
            await _repository.Update(id, cat);
            return _mapper.Map(cat);
        }
    }
}
