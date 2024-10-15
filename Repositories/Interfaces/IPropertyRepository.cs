using CatalogMicroservice.Models;

namespace CatalogMicroservice.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        public Task Add(Property property);
        public Task Update(long id,Property property);
        public Task Delete(long id);
        public Task<Property> GetById(long id);
        public Task<IEnumerable<Property>> GetAll();
        public Task<int> GetCount();
        //public Task<IEnumerable<Property>> GetByCategoryId(long categoryId);
        //public Task<IEnumerable<Property>> GetByProductId(long productId);
    }
}
