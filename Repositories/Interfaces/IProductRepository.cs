using CatalogMicroservice.Models;

namespace CatalogMicroservice.Repositories.Interfaces
{
    public interface IProductRepository
    {
        //Admin
        public Task Add(Product product);
        public Task Update(long id,Product product);
        public Task Delete(long id);
        //Prod
        public Task<Product> GetById(long id);
        public Task<IEnumerable<Product>> GetAll();
        public Task<IEnumerable<Product>> GetByCategory(long categoryId);
        public Task<IEnumerable<Product>> Filters();
        public Task<int> GetCount();
    }
}
