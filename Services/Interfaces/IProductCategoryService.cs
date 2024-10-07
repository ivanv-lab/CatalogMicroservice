using CatalogMicroservice.DTO;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductCategoryService
    {
        public Task<ProductCategoryDto> GetById(long id);
        public Task<IEnumerable<ProductCategoryDto>> GetAll(long id);
        public Task Create(ProductCategoryDto productCategoryDto);
        public Task Update(long id, ProductCategoryDto productCategoryDto);
        public Task Delete(long id);
        public Task<IEnumerable<ProductCategoryDto>> Search
            (string searchString);
    }
}
