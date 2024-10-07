using CatalogMicroservice.Models;

namespace CatalogMicroservice.Repositories.Interfaces
{
    public interface IProductPropertyValueRepository
    {
        //Admin
        public Task<IEnumerable<ProductPropertyValue>> GetAll();
        public Task Add(ProductPropertyValue productPropertyValue);
        public Task Update(long id,ProductPropertyValue productPropertyValue);
        public Task DeleteById(long id);
        //Prod
        public Task<ProductPropertyValue> GetById(long id);
        public Task<IEnumerable<ProductPropertyValue>> GetByProductId
            (long productId);
    }
}
