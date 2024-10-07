using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class ProductPropertyValueRepository :
        IProductPropertyValueRepository
    {
        private readonly CatalogDbContext _context;
        public ProductPropertyValueRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task Add(ProductPropertyValue productPropertyValue)
        {
            await _context.Values.AddAsync(productPropertyValue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(long id)
        {
            var value=await _context.Values.FindAsync(id);
            _context.Values.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductPropertyValue>> GetAll()
        {
            return await _context.Values.ToListAsync();
        }

        public async Task<ProductPropertyValue> GetById(long id)
        {
            return await _context.Values.FindAsync(id);
        }

        public async Task Update(long id, ProductPropertyValue productPropertyValue)
        {
            var value = await _context.Values.FindAsync(id);
            value = productPropertyValue;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductPropertyValue>> GetByProductId(long productId)
        {
            return await _context.Values
                .Where(ppv=>ppv.ProductId==productId)
                .ToListAsync();
        }
    }
}
