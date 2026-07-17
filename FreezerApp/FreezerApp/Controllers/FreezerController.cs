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
        public IActionResult SetTargetTemperature([FromBody] double temperatura)
        {
            _freezerService.SetTargetTemperature(temperatura);

            return Ok("Set target temperature to " + temperatura);
        }

        [HttpPost("cool")]
        public IActionResult CoolDown()
        {
            _freezerService.CoolDown();
            return Ok("Cooling down");
        }


        [HttpPut("ExpressFreezerOn")]
        public IActionResult ExpressFreezer()
        {
            _freezerService.ExpressFreezerOn();
            return Ok("Express Freezer activated");
        }   
    }
}
