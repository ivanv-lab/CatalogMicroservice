using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class CategoryPropertyService:
        ICategoryPropertyService
    {
        private readonly ICategoryPropertyRepository _repository;
        public CategoryPropertyService(ICategoryPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryProperty> Create(CategoryProperty categoryProperty)
        {
            await _repository.Add(categoryProperty);
            return categoryProperty;
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
