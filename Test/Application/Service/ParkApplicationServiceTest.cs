using Moq;
using Parking.Application.Service;
using Parking.Domain.ParkingBoys.Interface;
using Parking.ValueObject;
using Xunit;

namespace ParkingTest.Application.Service
{
    public class ParkApplicationServiceTest
    {
        [Fact]
        public void Park_should_park_by_parkableMock()
        {
            var parkableMock = new Mock<IParkable>();
            var service = new ParkApplicationService(parkableMock.Object);
            var car = new Car("川A 123456");

            service.Park(car);

            parkableMock.Verify(pm => pm.Park(car), Times.Once);
        }
    }
}