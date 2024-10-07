using CatalogMicroservice.DTO;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductPropertyValueService
    {
        public Task<IEnumerable<ProductPropertyValueDto>> GetByProductId
            (long productId);
        public Task<IEnumerable<ProductPropertyValueDto>> GetAll();
        public Task<ProductPropertyValueDto> Create(ProductPropertyValueDto productPropertyValueDto);
        public Task<ProductPropertyValueDto> Update(long id,
            ProductPropertyValueDto productPropertyValueDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductPropertyValueDto>> Search
            (string searchString);
    }
}
