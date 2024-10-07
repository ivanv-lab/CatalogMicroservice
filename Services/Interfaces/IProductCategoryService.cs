using CatalogMicroservice.DTO;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductCategoryService
    {
        public Task<ProductCategoryDto> GetById(long id);
        public Task<IEnumerable<ProductCategoryDto>> GetAll();
        public Task<ProductCategoryDto> Create(ProductCategoryDto productCategoryDto);
        public Task<ProductCategoryDto> Update(long id, ProductCategoryDto productCategoryDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductCategoryDto>> Search
            (string searchString);
    }
}
