using CatalogMicroservice.DTO;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto> GetById(long id);
        public Task<IEnumerable<ProductDto>> GetAll();
        public Task<IEnumerable<ProductDto>> GetByCategory(long categoryId);
        public Task<IEnumerable<ProductDto>> Filters(
            string? searchString, string? sortOrder,
            string? sortItem);
        public Task<ProductDto> Create(ProductCreateDto productDto);
        public Task<ProductDto> Update(long id, ProductUpdateDto productDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductDto>> Search(string? searchString);
        public Task<int> GetCount();
    }
}
