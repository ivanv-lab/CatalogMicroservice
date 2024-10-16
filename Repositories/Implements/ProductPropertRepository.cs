using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class ProductPropertRepository:
        IProductPropertyRepository
    {
        private readonly CatalogDbContext _context;
        public ProductPropertRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductProperty productProperty)
        {
            await _context.ProductProperties.AddAsync(productProperty);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var prodProp=await _context.ProductProperties.FindAsync(id);
            _context.ProductProperties.Remove(prodProp);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductProperty>> GetAll()
        {
            return await _context.ProductProperties.ToListAsync();
        }

        public async Task<ProductProperty> GetById(long id)
        {
            return await _context.ProductProperties.FindAsync(id);
        }

        public async Task Update(long id, ProductProperty productProperty)
        {
            var prodProp = await _context.ProductProperties.FindAsync(id);
            prodProp.Value= productProperty.Value;
            await _context.SaveChangesAsync();
        }
    }
}
