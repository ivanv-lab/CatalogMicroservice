using CatalogMicroservice.Models;

namespace CatalogMicroservice.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        //Admin
        public Task Add(ProductCategory category);
        public Task Update(long id,ProductCategory category);
        public Task Delete(long id);
        //Prod
        public Task<ProductCategory> GetById(long id);
        public Task<IEnumerable<ProductCategory>> GetAll();
    }
}
