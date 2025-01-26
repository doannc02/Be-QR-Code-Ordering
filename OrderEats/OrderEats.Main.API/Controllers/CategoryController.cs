using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.Filter;

namespace OrderEats.Main.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _categoryService.GetList();
            return Ok(new { message = "Order placed successfully!", data = res });
        }
    }
}
