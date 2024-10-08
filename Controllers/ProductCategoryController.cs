using CatalogMicroservice.DTO;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController:ControllerBase
    {
        private readonly IProductCategoryService _service;
        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category=await _service.GetById(id);
            return Ok(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAll();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create
            ([FromBody] ProductCategoryCreateDto request)
        {
            var newCat=await _service.Create(request);
            return Ok(newCat);
        }

        [HttpPost]
        public async Task<IActionResult> Update
            ([FromBody] ProductCategoryCreateDto request)
        {
            var updateCategory = await _service
                .Update(request.Id, request);
            return Ok(updateCategory);
        }
    }
}
