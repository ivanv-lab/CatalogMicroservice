using CatalogMicroservice.Models;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface ICategoryPropertyService
    {
        public Task<CategoryProperty> Create(CategoryProperty categoryProperty);
        public Task<CategoryProperty> Update(long id,
            CategoryProperty categoryProperty);
        public Task<bool> Delete(long id);
        public Task<CategoryProperty> GetById(long id);
        public Task<IEnumerable<CategoryProperty>> GetAll();
        public Task<IEnumerable<CategoryProperty>> GetByCategoryid(long id);
        public Task<IEnumerable<CategoryProperty>> GetByPropertyId(long id);
    }
}
