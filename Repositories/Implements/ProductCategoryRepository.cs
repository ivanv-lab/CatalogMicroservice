using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class ProductCategoryRepository:
        IProductCategoryRepository
    {
        private readonly CatalogDbContext _context;
        public ProductCategoryRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductCategory category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var category=await _context.Categories.FindAsync(id);
            category.IsDeleted= true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _context.Categories.
                Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<ProductCategory> GetById(long id)
        {
            return await _context.Categories
                .Where(c => !c.IsDeleted &&
                c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Categories
                .Where(c=>!c.IsDeleted)
                .CountAsync();
        }

        public async Task Update(long id, ProductCategory category)
        {
            var cat = await _context.Categories.FindAsync(id);
            cat.Name=category.Name;
            await _context.SaveChangesAsync();
        }
    }
}
