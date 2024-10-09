using CatalogMicroservice.DTO;
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace CatalogMicroservice.Services.Implements
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ProductMapper _mapper;
        public ProductService(IProductRepository repository, ProductMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductCreateDto productDto)
        {
            var prod=_mapper.Map(productDto);
            await _repository.Add(prod);
            prod=await _repository.GetById(prod.Id);
            return _mapper.Map(prod);
        }

        public async Task<bool> Delete(long id)
        {
            var prod=await _repository.GetById(id);
            if (prod != null)
            {
                await _repository.Delete(id);
                return true;
            }
            return false;
        }

        public Task<IEnumerable<ProductDto>> Filters(
            string? searchString,
            string? sortOrder,
            string? sortItem)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var prods=await _repository.GetAll();
            return _mapper.MapList(prods);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategory(long categoryId)
        {
            var prods=await _repository.GetByCategory(categoryId);
            return _mapper.MapList(prods);
        }

        public async Task<ProductDto> GetById(long id)
        {
            var prod=await _repository.GetById(id);
            return _mapper.Map(prod);
        }

        public async Task<IEnumerable<ProductDto>> Search(string searchString)
        {
            var prods = await _repository.GetAll();

            if(!string.IsNullOrEmpty(searchString)
                || searchString==" ")
            {
                searchString = searchString.ToLower();
                prods=prods.Where(p=>p.Id.ToString().Contains(searchString)
                || p.Name.ToLower().Contains(searchString)
                || p.Price.ToString().Contains(searchString)
                || p.Count.ToString().Contains(searchString)
                || p.Category.Name.ToLower().Contains(searchString));
            }

            return _mapper.MapList(prods);
        }

        public async Task<ProductDto> Update(long id, ProductUpdateDto productDto)
        {
            var prod=_mapper.Map(productDto);
            await _repository.Update(id, prod);
            return _mapper.Map(prod);
        }
        public async Task<int> GetCount()
        {
            return await _repository.GetCount();
        }
    }
}
