using CatalogMicroservice.DTO.CategoryProperty;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class CategoryPropertyService:
        ICategoryPropertyService
    {
        private readonly ICategoryPropertyRepository _repository;
        private readonly CategoryPropertyMapper _mapper;
        public CategoryPropertyService(
            ICategoryPropertyRepository repository,
            CategoryPropertyMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryProperty> Create(CategoryPropertyCreateDto categoryProperty)
        {
            var catProp = _mapper.Map(categoryProperty);
            await _repository.Add(catProp);
            return catProp;
        }

        public async Task<bool> Delete(long id)
        {
            var catProp=await _repository.GetById(id);
            if (catProp != null)
            {
                await _repository.Delete(id);
                return true;
            }
            return false; 
        }

        public async Task<IEnumerable<CategoryProperty>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<CategoryProperty>> GetByCategoryid(long id)
        {
            return await _repository.GetByCategoryId(id);
        }

        public async Task<CategoryProperty> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<CategoryProperty>> GetByPropertyId(long id)
        {
            return await _repository.GetByPropertyId(id);
        }

        public async Task<CategoryProperty> Update(long id, CategoryProperty categoryProperty)
        {
            await _repository.Update(id, categoryProperty);
            return categoryProperty;
        }
    }
}
