
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
        public async Task<IActionResult> Filters(
            [FromQuery]string? searchString,
            [FromQuery]string? sortOrder,
            [FromQuery]string? sortItem,
            [FromQuery]int page=1)
        {
            return Ok();
            //Доделать
        }
        [HttpPost]
        public async Task<IActionResult> Create
            ([FromBody] ProductCreateDto request)
        {
            var prod=await _service.Create(request);
            return Ok(prod);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update
            ([FromBody] ProductCreateDto request)
        {
            var updateProd = await _service
                .Update(request.Id, request);
            return Ok(updateProd);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var prod=await _service.Delete(id);
            if (prod)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("search/")]
        public async Task<IActionResult> Search(
            [FromQuery] string? sesarchString,
            [FromQuery]int page=1)
        {
            const int pageSize = 10;
            var products = await _service.Search(sesarchString);
            products = products.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var count = await _service.GetCount();
            var response = new
            {
                items = products,
                currentPage = page,
                totalPages =
                (int)Math.Ceiling((double)count / pageSize),
                totalCount = count
            };
            return Ok(response);
        }
    }
}
