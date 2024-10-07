using CatalogMicroservice.DTO;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto> GetById(long id);
        public Task<IEnumerable<ProductDto>> GetAll();
        public Task<IEnumerable<ProductDto>> GetByCategory(long categoryId);
        public Task<IEnumerable<ProductDto>> Filters();
        public Task Create(ProductDto productDto);
        public Task Update(long id,ProductDto productDto);
        public Task Delete(long id);
        public Task<IEnumerable<ProductDto>> Search(string searchString);
    }
}
