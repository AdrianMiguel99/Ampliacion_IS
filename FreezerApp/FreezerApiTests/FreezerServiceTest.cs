
using NUnit.Framework;
using FreezerApi.Services;
namespace FreezerApp.FreezerApiTests
{   
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {   
            setTargetTemperature_InvalidTemperature_ShouldThrowException();
            setTargetTemperature_ValidTemperature_ShouldSetTemperature();
            expressFreezerOn_ShouldSetExpressFreezerOn();
        }

        [Test]
        public void setTargetTemperature_ValidTemperature_ShouldSetTemperature()
        {
            // Arrange
            var freezerService = new FreezerService();

            // Act
            freezerService.SetTargetTemperature(-5.0);

            // Assert
            Assert.AreEqual(-5.0, freezerService.GetTargetTemperature());

        }

        [Test]
        public void setTargetTemperature_InvalidTemperature_ShouldThrowException()
        {
            // Arrange
            var freezerService = new FreezerService();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => freezerService.SetTargetTemperature(10.0));
        }

        [Test]
        public void expressFreezerOn_ShouldSetExpressFreezerOn()
        {
            // Arrange
            var freezerService = new FreezerService();
            // Act
            freezerService.ExpressFreezerOn();
            // Assert
            Assert.IsTrue(freezerService.IsExpressFreezerOn());
        }
    }
}
