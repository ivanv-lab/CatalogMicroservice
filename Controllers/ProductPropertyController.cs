using CatalogMicroservice.Models;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertyController:ControllerBase
    {
        private readonly IProductPropertyService _service;
        public ProductPropertyController(IProductPropertyService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var prodProp = await _service.GetById(id);
            return Ok(prodProp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prodProps=await _service.GetAll();
            return Ok(prodProps);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Create(
            [FromBody]ProductProperty request)
        {
            var newProdProp=await _service.Create(request);
            return Ok(newProdProp);
        }
        [HttpPut("upd")]
        public async Task<IActionResult> Update(
            [FromBody]ProductProperty request)
        {
            var updateProdProp = await _service
                .Update(request.Id, request);
            return Ok(updateProdProp);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool res = await _service.Delete(id);
            if (res)
                return Ok();
            return BadRequest();
        }
    }
}
