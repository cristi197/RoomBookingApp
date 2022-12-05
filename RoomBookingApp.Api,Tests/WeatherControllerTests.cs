using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using RoomBookingApp.Api.Controllers;
using Shouldly;
using Xunit;

namespace RoomBookingApp.Api_Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void Should_Return_Forcast_Results()
        {
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            var result = controller.Get();


            result.ShouldNotBeNull();
            result.Count().ShouldBeGreaterThan(1);
        }
    }
}