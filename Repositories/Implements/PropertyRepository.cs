using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogMicroservice.Repositories.Implements
{
    public class PropertyRepository :
        IPropertyRepository
    {
        private readonly CatalogDbContext _context;
        public PropertyRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task Add(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var prop=await _context.Properties.FindAsync(id);
            _context.Properties.Remove(prop);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetAll()
        {
            return await _context
                .Properties.ToListAsync();
        }

        //Этот метод должен быть у CategoryProperties
        //public async Task<IEnumerable<Property>> GetByCategoryId(long categoryId)
        //{
           
        //}

        public async Task<Property> GetById(long id)
        {
            return await _context.Properties
                .Where(p=>p.Id==id)
                .FirstOrDefaultAsync();
        }

        //Этот метод должен быть у ProductProperties
        //public async Task<IEnum erable<Property>> GetByProductId(long productId)
        //{

        //}

        public async Task<int> GetCount()
        {
            return await _context
                .Properties.CountAsync();
        }

        public async Task Update(long id, Property property)
        {
            var prop = await _context.Properties.FindAsync(id);
            prop.Name= property.Name;
            await _context.SaveChangesAsync();
        }
    }
}
