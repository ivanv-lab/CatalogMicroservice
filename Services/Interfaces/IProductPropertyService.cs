using CatalogMicroservice.DTO;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductPropertyService
    {
        public Task<IEnumerable<ProductPropertyDto>> GetAll();
        public Task<ProductPropertyDto> Create(ProductPropertyDto productPropertyDto);
        public Task<ProductPropertyDto> Update(long id,
            ProductPropertyDto productPropertyDto);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductPropertyDto>> Search
            (string searchString);
    }
}
