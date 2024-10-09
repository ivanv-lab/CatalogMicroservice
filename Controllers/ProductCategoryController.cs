using CatalogMicroservice.DTO;
using CatalogMicroservice.DTO.ProductCategory;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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
        /// <summary>
        /// Получение категории по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category=await _service.GetById(id);
            return Ok(category);
        }
        /// <summary>
        /// Получение всех категорий
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAll();
            return Ok(categories);
        }
        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Create
            ([FromBody] ProductCategoryCreateDto request)
        {
            var newCat=await _service.Create(request);
            return Ok(newCat);
        }
        /// <summary>
        /// Обновление категории
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("upd")]
        public async Task<IActionResult> Update
            ([FromBody] ProductCategoryUpdateDto request)
        {
            var updateCategory = await _service
                .Update(request.Id, request);
            return Ok(updateCategory);
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var cat = await _service.GetById(id);
            if (cat != null)
            {
                await _service.Delete(id);
                return Ok(cat);
            }
            return BadRequest();
        }
        /// <summary>
        /// Поиск категории по наименованию и id
        /// </summary>
        /// <param name="searchStirng"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery]string? searchStirng,
            [FromQuery]int page = 1)
        {
            const int pageSize = 10;
            var categories = await _service.Search(searchStirng);
            categories=categories.Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();
            var count = await _service.GetCount();
            var response = new
            {
                items = categories,
                currentPage = page,
                totalPages =
                (int)Math.Ceiling((double)count / pageSize),
                totalCount = count
            };
            return Ok(response);
        }
    }
}
