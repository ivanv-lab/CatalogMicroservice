using CatalogMicroservice.DTO;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductPropertyValueService
    {
        public Task<IEnumerable<ProductPropertyValueDto>> GetByProductId
            (long productId);
        public Task<IEnumerable<ProductPropertyValueDto>> GetAll();
        public Task Create(ProductPropertyValueDto productPropertyValueDto);
        public Task Update(long id,
            ProductPropertyValueDto productPropertyValueDto);
        public Task Delete(long id);
        public Task<IEnumerable<ProductPropertyValueDto>> Search
            (string searchString);
    }
}
