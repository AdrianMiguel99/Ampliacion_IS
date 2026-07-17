

namespace FreezerApp.FreezerApiTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {   
            setTargetTemperature_InvalidTemperature_ShouldThrowException();
            setTargetTemperature_ValidTemperature_ShouldSetTemperature();
        }

        [Test]
        public void setTargetTemperature_ValidTemperature_ShouldSetTemperature()
        {
            // Arrange
            var freezerService = new FreezerApi.Service.FreezerService();

            // Act
            freezerService.SetTargetTemperature(-5.0);

            // Assert
            Assert.AreEqual(-5.0, freezerService.GetTargetTemperature());

        }

        [Test]
        public void setTargetTemperature_InvalidTemperature_ShouldThrowException()
        {
            // Arrange
            var freezerService = new FreezerApi.Service.FreezerService();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => freezerService.SetTargetTemperature(10.0));
        }
    }
}
