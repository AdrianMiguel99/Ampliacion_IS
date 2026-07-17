using FreezerApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace FreezerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FreezerController : ControllerBase
    {   
        IFreezerService _freezerService;
        public FreezerController(IFreezerService freezerService)
        {
            _freezerService = freezerService;
        }



        [HttpPost("{temperature}")]
        public IActionResult SetTargetTemperature([FromBody] int temperatura)
        {
            _freezerService.SetTargetTemperature(temperatura);
        }

        [HttpPost("cool")]
        public IActionResult CoolDown()
        {
            _freezerService
        }


        [HttpPut("ExpressFreezer")]
        public IActionResult ExpressFreezer()
        {
            _freezerService.ExpressFreezer();
            return Ok("Express Freezer activated");
        }   
    }
}
