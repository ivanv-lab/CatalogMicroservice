using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice.Services.Implements
{
    public class ProductPropertyService:
        IProductPropertyService
    {
        private readonly IProductPropertyRepository _repository;
        public ProductPropertyService(IProductPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductProperty> Create(ProductProperty productProperty)
        {
            await _repository.Add(productProperty);
            return productProperty;
        }

        public async Task<bool> Delete(long id)
        {
            var prodProp = await _repository.GetById(id);
            if (prodProp != null)
            {
                await _repository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductProperty>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ProductProperty> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ProductProperty> Update(long id, ProductProperty productProperty)
        {
            await _repository.Update(id, productProperty);
            return productProperty;
        }
    }
}
