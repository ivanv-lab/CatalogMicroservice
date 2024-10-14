using CatalogMicroservice.Models;

namespace CatalogMicroservice.Repositories.Interfaces
{
    public interface IProductPropertyRepository
    {
        public Task<IEnumerable<ProductProperty>> GetAll();
        public Task Add(ProductProperty productProperty);
        public Task Update(long id, ProductProperty productProperty);
        public Task Delete(long id);
        public Task<ProductProperty> GetById(long id);
        public Task<int> Count();
    }
}
