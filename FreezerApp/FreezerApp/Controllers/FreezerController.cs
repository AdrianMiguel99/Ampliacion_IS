using Microsoft.AspNetCore.Mvc;

namespace FreezerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FreezerController : ControllerBase
    {
        


        [HttpPost("target-temperature")]
        public IActionResult SetTargetTemperature(double temperature)
        {
            
        }

        [HttpPost("cool")]
        public IActionResult CoolDown()
        {
            if (!_poweredOn)
            {
                return BadRequest("Freezer is off");
            }

            int resourcesUsed = CalculateResources();

            _currentTemperature -= resourcesUsed * 0.05;

            if (_currentTemperature < _targetTemperature)
            {
                _currentTemperature = _targetTemperature;
            }

            return Ok(new
            {
                Message = "Cooling completed",
                CurrentTemperature = _currentTemperature
            });
        }

        private int CalculateResources()
        {
            double difference =
                _currentTemperature - _targetTemperature;

            //30 is the the difference between the current temperature and the target temperature, if the difference is greater than 30, the qty of resources used is 150
            // those are grades 
            if (difference > 30)
            {
                //Qty of resources used is 150 if the difference is greater than 30
                return 150;
            }

            //20 is the the difference between the current temperature and the target temperature, if the difference is greater than 20, the qty of resources used is 120
            // those are grades
            if (difference > 20)
            {
                //Qty of resources used is 120 if the difference is greater than 20
                return 120;
            }

            //10 is the the difference between the current temperature and the target temperature, if the difference is greater than 10, the qty of resources used is 100
            // those are grades
            if (difference > 10)
            {
                //Qty of resources used is 100 if the difference is greater than 10
                return 100;
            }

            return 50;
        }
    }
}
