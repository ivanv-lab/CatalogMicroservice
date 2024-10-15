using CatalogMicroservice.Models;

namespace CatalogMicroservice.Repositories.Interfaces
{
    public interface ICategoryPropertyRepository
    {
        public Task Add(CategoryProperty categoryProperty);
        public Task Update(long id,CategoryProperty categoryProperty);
        public Task Delete(long id);
        public Task<CategoryProperty> GetById(long id);
        public Task<IEnumerable<CategoryProperty>> GetAll();
        public Task<IEnumerable<CategoryProperty>> GetByCategoryId(long categoryId);
        public Task<IEnumerable<CategoryProperty>> GetByPropertyId(long propertyId);
    }
}
