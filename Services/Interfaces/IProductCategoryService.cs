using CatalogMicroservice.DTO;
using CatalogMicroservice.DTO.ProductCategory;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductCategoryService
    {
        public Task<ProductCategoryDto> GetById(long id);
        public Task<IEnumerable<ProductCategoryDto>> GetAll();
        public Task<ProductCategoryDto> Create(ProductCategoryCreateDto productCategoryDto);
        public Task<ProductCategoryDto> Update(long id, ProductCategoryUpdateDto productCategoryDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductCategoryDto>> Search
            (string? searchString);
        public Task<int> GetCount();
    }
}
