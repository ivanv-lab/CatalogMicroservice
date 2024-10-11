
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
        /// <summary>
        /// Получение всех товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =await _service.GetAll();
            return Ok(products);
        }
        /// <summary>
        /// Получение товара по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var prod = await _service.GetById(id);
            return Ok(prod);
        }
        /// <summary>
        /// Получение товара по id категории
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("categoryId")]
        public async Task<IActionResult> GetByCategoryId(long categoryId)
        {
            var prods = await _service.GetByCategory(categoryId);
            return Ok(prods);
        }
        /// <summary>
        /// Фильтры для бокового поиска товара
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="sortOrder"></param>
        /// <param name="sortItem"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet("filters")]
        public async Task<IActionResult> Filters(
            [FromQuery] string? searchString,
            [FromQuery] string? sortOrder,
            [FromQuery] string? sortItem,
            [FromQuery] int page = 1)
        {
            return Ok();
            //Доделать
        }
        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Create
            ([FromBody] ProductCreateDto request)
        {
            var prod = await _service.Create(request);
            return Ok(prod);
        }
        /// <summary>
        /// Обновление товара
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("upd")]
        public async Task<IActionResult> Update
            ([FromBody] ProductUpdateDto request)
        {
            var updateProd = await _service
                .Update(request.Id, request);
            return Ok(updateProd);
        }
        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var prod = await _service.Delete(id);
            if (prod)
            {
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        /// Посик товара по полям
        /// </summary>
        /// <param name="sesarchString"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? sesarchString,
            [FromQuery] int page = 1)
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
