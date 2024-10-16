using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class CategoryPropertyRepository :
        ICategoryPropertyRepository
    {
        private readonly CatalogDbContext _context;
        public CategoryPropertyRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task Add(CategoryProperty categoryProperty)
        {
            await _context.CategoriesProperties
                .AddAsync(categoryProperty);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var catProp=await _context.CategoriesProperties
                .FindAsync(id);
            _context.CategoriesProperties.Remove(catProp);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryProperty>> GetAll()
        {
            return await _context.CategoriesProperties
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryProperty>> GetByCategoryId(long categoryId)
        {
            return await _context.CategoriesProperties
                .Where(cp => cp.CategoryId == categoryId)
                .ToListAsync() ?? null;
        }

        public async Task<CategoryProperty> GetById(long id)
        {
            return await _context.CategoriesProperties.FindAsync(id);
        }

        public async Task<IEnumerable<CategoryProperty>> GetByPropertyId(long propertyId)
        {
            return await _context.CategoriesProperties
                .Where(cp=>cp.PropertyId == propertyId)
                .ToListAsync();
        }

        public async Task Update(long id, CategoryProperty categoryProperty)
        {
            var catProp=await _context.CategoriesProperties.FindAsync(id);
            catProp.CategoryId=categoryProperty.CategoryId;
            catProp.PropertyId = categoryProperty.PropertyId;
            await _context.SaveChangesAsync();
        }
    }
}
