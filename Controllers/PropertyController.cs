using CatalogMicroservice.DTO.Property;
using CatalogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController:ControllerBase
    {
        private readonly IPropertyService _service;
        public PropertyController(IPropertyService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var prop=await _service.GetById(id);
            return Ok(prop);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var props = await _service.GetAll();
            return Ok(props);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Create
            ([FromBody] PropertyCreateDto request)
        {
            var newProp=await _service.Create(request);
            return Ok(newProp);
        }
        [HttpPut("upd")]
        public async Task<IActionResult> Update
            ([FromBody] PropertyUpdateDto request)
        {
            var updProp = await _service
                .Update(request.Id, request);
            return Ok(updProp);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool res=await _service.Delete(id);
            if(res)
                return Ok();
            return BadRequest();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? searchString,
            [FromQuery] int page = 1)
        {
            const int pageSize = 10;
            var props= await _service.Search(searchString);
            props=props.Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();
            var count = await _service.GetCount();
            var response = new
            {
                items = props,
                currentPage = page,
                totalPages =
                (int)Math.Ceiling((double)count / pageSize),
                totalCount = count
            };
            return Ok(response);
        }
    }
}
