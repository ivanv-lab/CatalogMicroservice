using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class ProductRepository:IProductRepository
    {
        private readonly CatalogDbContext _context;
        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var prod=await _context.Products.FindAsync(id);
            prod.IsDeleted= true;
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Product>> Filters()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p=>p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(long categoryId)
        {
            return await _context.Products
                .Where(p=>!p.IsDeleted &&
                p.ProductCategoryId==categoryId)
                .Include(p=>p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetById(long id)
        {
            return await _context.Products
                .Where(p => !p.IsDeleted &&
                p.Id == id)
                .Include(p => p.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Products
                .Where(p=>!p.IsDeleted)
                .CountAsync();
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
