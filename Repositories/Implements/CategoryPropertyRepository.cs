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
                .Where()
        }

        public Task<CategoryProperty> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryProperty>> GetByPropertyId(long propertyId)
        {
            throw new NotImplementedException();
        }

        public Task Update(long id, CategoryProperty categoryProperty)
        {
            throw new NotImplementedException();
        }
    }
}
