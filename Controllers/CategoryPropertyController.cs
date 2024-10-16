using CatalogMicroservice.Models;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryPropertyController:ControllerBase
    {
        private readonly ICategoryPropertyService _service;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var catProp=await _service.GetById(id);
            return Ok(catProp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var catProps=await _service.GetAll();
            return Ok(catProps);
        }
        [HttpGet("catId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryid(long categoryId)
        {
            var catProps = await _service.GetByCategoryid(categoryId);
            return Ok(catProps);
        }
        [HttpGet("propId/{propertyId}")]
        public async Task<IActionResult> GetByPropertyId(long propertyId)
        {
            var catProps = await _service.GetByPropertyId(propertyId);
            return Ok(catProps);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Create
            ([FromBody] CategoryProperty request)
        {
            var newCatProp=await _service.Create(request);
            return Ok(newCatProp);
        }
        [HttpPut("upd")]
        public async Task<IActionResult> Update
            ([FromBody] CategoryProperty request)
        {
            var updateCatProp = await _service
                .Update(request.Id, request);
            return Ok(updateCatProp);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool res=await _service.Delete(id);
            if(res)
                return Ok();
            return BadRequest();
        }
    }
}
