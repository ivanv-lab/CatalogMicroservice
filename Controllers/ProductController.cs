
using CatalogMicroservice.DTO;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =await _service.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var prod=await _service.GetById(id);
            return Ok(prod);
        }
        [HttpGet("categoryId/{id}")]
        public async Task<IActionResult> GetByCategoryId(long categoryId)
        {
            var prods = await _service.GetByCategory(categoryId);
            return Ok(prods);
        }
        [HttpGet("filters/")]
        public async Task<IActionResult> Filters()
        {
            //Доделать
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create
            ([FromBody] ProductDto request)
        {
            var prod=await _service.Create(request);
            return Ok(prod);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update
            ([FromBody] ProductDto request)
        {
            var newProd=
        }
        [HttpPost("delete/{id}")]
        public Task<IActionResult> Delete(long id)
        {

        }
        [HttpGet("search/")]
        public async Task<IActionResult> Search()
        {
            //Доделать
            return Ok();
        }
    }
}
