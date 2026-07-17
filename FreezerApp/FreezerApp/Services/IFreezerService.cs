namespace FreezerApi.Service
{
    public interface IFreezerService
    {
        void SetTargetTemperature(double temperature);
        double GetCurrentTemperature();
        double GetTargetTemperature();
        bool IsPoweredOn();
        void PowerOn();
        void PowerOff();
        int CalculateResources();
        public void ExpressFreezerOn();
        public void ExpressPowerOff();

        public void CoolDown();

    }
}
