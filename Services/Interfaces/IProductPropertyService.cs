using CatalogMicroservice.Models;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductPropertyService
    {
        public Task<ProductProperty> GetById(long id);
        public Task<IEnumerable<ProductProperty>> GetAll();
        public Task<ProductProperty> Create(ProductProperty productProperty);
        public Task<ProductProperty> Update(long id,ProductProperty productProperty);
        public Task<bool> Delete(long id);

    }
}
