using FreezerApi.Service;
using System;
namespace FreezerApi.Services
{
    public class FreezerService : IFreezerService
    {
        private static bool _poweredOn = true;
        private static double _currentTemperature = 5;
        private static double _targetTemperature = -18;

        public FreezerService() { }

        void SetTargetTemperature(double temperature)
        {   
            if (!_poweredOn)
            {
                throw new InvalidOperationException("Freezer is off");
            }

            if (GetCurrentTemperature() > 0)
            {
                throw new ArgumentOutOfRangeException("Target temperature must be below 0");
            }
            _targetTemperature = temperature;

            return Ok("Target temperature updated");

        }

        public double GetTargetTemperature()
        {
            return _targetTemperature;
        }

        public double GetCurrentTemperature()
        {
            return _currentTemperature;
        }

        public int CalculateResources()
        {
            double difference = GetCurrentTemperature() - GetTargetTemperature();

            if (difference > 30)
            {
                return 150;
            }
            if (difference > 20)
            {
                return 120;
            }
            if (difference > 10)
            {
                return 100;
            }
            return 50;
        }
    }
}
