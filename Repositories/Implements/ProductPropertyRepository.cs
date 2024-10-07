using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class ProductPropertyRepository :
        IProductPropertyRepository
    {
        private readonly CatalogDbContext _context;
        public ProductPropertyRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task Add(ProductProperty productProperty)
        {
            await _context.Properties.AddAsync(productProperty);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var prop=await _context.Properties.FindAsync(id);
            _context.Properties.Remove(prop);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductProperty>> GetAll()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<ProductProperty> GetById(long id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task Update(long id, ProductProperty productProperty)
        {
            var prop = await _context.Properties.FindAsync(id);
            prop = productProperty;
            await _context.SaveChangesAsync();
        }
    }
}
