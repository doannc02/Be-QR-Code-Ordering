using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.DTO;

namespace OrderEats.Main.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _serivce;
        public TableController(ITableService service) { 
            _serivce = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var lstTable = await _serivce.GetAll();
            return Ok(new { message = "Table placed successfully!", data = lstTable });
        }

        [HttpGet]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {
            var res  = await _serivce.Get(id);
            return Ok(new { message = "Table placed successfully!", data = res });
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<TableDTO> tableDto)
        {
            var res = await _serivce.AddMultiTable(tableDto);
            return Ok(new
            {
                message = "Add new Table successfully!",
                data = new
                {
                    isSuccess = res
                }
            } );
        }
    }
}
