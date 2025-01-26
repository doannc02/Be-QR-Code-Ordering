using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Application.Mapper;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Filter;
using OrderEats.Main.API.Services;

namespace OrderEats.Main.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;

        public FoodItemController(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> FindFoodItemAsync([FromQuery] ParamsFindByCategory query)
        {
            var res = await _foodItemService.FindFoodItemAsyncByCategory(query);
            return Ok(new { message = "Order placed successfully!", data = res });
        }
    }
}
