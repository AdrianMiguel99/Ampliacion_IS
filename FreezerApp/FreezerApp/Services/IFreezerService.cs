using FreezerApi.Models;
namespace FreezerApi.Service
{
    public interface IFreezerService
    {
        void SetTargetTemperature(double temperature);
        double GetCurrentTemperature();
        double GetTargetTemperature();
        void PowerOn();
        void PowerOff();
        double CalculateResources(FreezeProfile profile);
        public void ExpressFreezerOn();
        public void ExpressFreezerOff();
        public void CoolDown();

        public bool IsExpressFreezerOn();

    }
}
