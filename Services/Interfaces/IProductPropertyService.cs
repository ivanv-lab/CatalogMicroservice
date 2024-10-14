using CatalogMicroservice.DTO;
using CatalogMicroservice.DTO.ProductProperty;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductPropertyService
    {
        public Task<IEnumerable<ProductPropertyDto>> GetAll();
        public Task<ProductPropertyDto> GetById(long id);
        public Task<ProductPropertyDto> Create(ProductPropertyCreateDto productPropertyDto);
        public Task<ProductPropertyDto> Update(long id,
            ProductPropertyUpdateDto productPropertyDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductPropertyDto>> Search
            (string? searchString);
        public Task<int> Count();
    }
}
