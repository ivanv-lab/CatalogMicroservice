using CatalogMicroservice.DTO;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Services.Interfaces
{
    public interface IProductPropertyService
    {
        public Task<IEnumerable<ProductPropertyDto>> GetAll();
        public Task Create(ProductPropertyDto productPropertyDto);
        public Task Update(long id,
            ProductPropertyDto productPropertyDto);
        public Task Delete(long id);
        public Task<IEnumerable<ProductPropertyDto>> Search
            (string searchString);
    }
}
