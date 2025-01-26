using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.DTO;

namespace OrderEats.Main.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService ;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateOrder([FromBody]OrderDTO dto)
        {
            var res = await _orderService.CreateOrderAsync(dto);
            return Ok(new { message = "Order placed successfully!", data = res });
        }
    }
}
