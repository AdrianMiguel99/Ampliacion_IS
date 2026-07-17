using System;
using FreezerApi.Models;

namespace FreezerApi.Services
{
    public class FreezerService : IFreezerService
    {
        private double ExpressFreezerPorcentage = 0.4;
        private static bool _poweredOn = true;
        private static double _currentTemperature = 5;
        private static double _targetTemperature = -18;
        private bool _expressFreezerOn = false;



        public void coolDown()
        {
            if (!_poweredOn)
            {
                throw new InvalidOperationException("Freezer is off");
            }


            double resourcesUsed = CalculateResources(CreateDefaultProfile());

            _currentTemperature -= resourcesUsed * 0.05;

            if (_currentTemperature < _targetTemperature)
            {
                _currentTemperature = _targetTemperature;
            }

            return;
        }

        public void ExpressFreezerOn()
        {
            if (!_poweredOn)
            {
                throw new InvalidOperationException("Freezer is off");
            }

            double resourcesUsed = CalculateResources(CreateDefaultProfile());
            _currentTemperature -= resourcesUsed * 0.05 * ExpressFreezerPorcentage;
            if (_currentTemperature < _targetTemperature)
            {
                _currentTemperature = _targetTemperature;
            }
            _expressFreezerOn = true;
            // Simulate the express freezer being on for a short period of time
            // Lo ideal seria que se implementara un temporizador para que el express
            // freezer se apague automaticamente despues de un tiempo determinado, pero por simplicidad se omite en este ejemplo.
            // Ademas el timer deberia ser implementado en un hilo aparte para no bloquear el hilo principal de la aplicacion.

            ExpressFreezerOff();

            return;
        }



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

            return;
        }

        public void PowerOn()
        {
            _poweredOn = true;
        }

        public void PowerOff()
        {
            _poweredOn = false;
        }

        public double GetTargetTemperature()
        {
            return _targetTemperature;
        }

        public double GetCurrentTemperature()
        {
            return _currentTemperature;
        }

        public double CalculateResources(FreezeProfile freezeProfile)
        {
            double difference = GetCurrentTemperature() - GetTargetTemperature();

            if (difference > 30)
            {
                return freezeProfile.CostGreaterThanThirty;
            }
            if (difference > 20)
            {
                return freezeProfile.CostGreaterThanTwenty;
            }
            if (difference > 10)
            {
                return freezeProfile.CostGreaterThanTen;
            }
            return freezeProfile.DefaultCost;
        }

        private FreezeProfile CreateDefaultProfile()
        {
            FreezeProfile freezeProfile = new FreezeProfile();
            freezeProfile.Tipo = "Default";
            freezeProfile.CostGreaterThanThirty = 150;
            freezeProfile.CostGreaterThanTwenty = 120;
            freezeProfile.CostGreaterThanTen = 100;
            freezeProfile.DefaultCost = 50;
            return freezeProfile;
        }

        public void ExpressFreezerOff()
        {
            if (!_poweredOn)
            {
                throw new InvalidOperationException("Freezer is off");
            }
            _expressFreezerOn = false;
        }
    }
}
