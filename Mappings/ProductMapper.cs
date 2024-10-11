using CatalogMicroservice.DTO;
using CatalogMicroservice.Models;

namespace CatalogMicroservice.Mappings
{
    public class ProductMapper
    {
        private readonly ProductCategoryMapper _mapper;
        public ProductMapper(ProductCategoryMapper mapper)
        {
            _mapper = mapper;
        }
        public Product Map(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Count = dto.Count,
                Price = dto.Price,
                Category = _mapper.Map(dto.Category)
            };
        }
        public ProductDto Map(Product model)
        {
            return new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Count = model.Count,
                Price = model.Price,
                Category = _mapper.Map(model.Category)
            };
        }
        public Product Map(ProductCreateDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Count = dto.Count,
                Price = dto.Price,
                ProductCategoryId = dto.ProductCategoryId
            };
        }
        public Product Map(ProductUpdateDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Count = dto.Count,
                Price = dto.Price,
                ProductCategoryId = dto.ProductCategoryId,
            };
        }
        public IEnumerable<ProductDto> MapList(
            IEnumerable<Product> models)
        {
            List<ProductDto> result = new List<ProductDto>();
            foreach (var model in models)
            {
                result.Add(Map(model));
            }
            return result;
        }
        public Product UpdateMap(Product model,ProductUpdateDto dto)
        {
            model.Name= dto.Name;
            model.Count= dto.Count;
            model.Price= dto.Price;
            model.ProductCategoryId= dto.ProductCategoryId;
            return model;
        }
    }
}
