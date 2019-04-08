using Parking.Application.Service;
using Parking.ValueObject;
using Xunit;

namespace ParkingTest.Application.Service
{
    public class ParkApplicationServiceTest
    {
        private ParkApplicationService _service;

        public ParkApplicationServiceTest()
        {
            // _service = new ParkApplicationService();
        }

        [Fact]
        public void Park_should_park_by_parkableMock()
        {
            var car = new Car("川A 123456");

            _service.Park(car);

            // _parkableMock.Verify(pm => pm.Park(car), Times.Once);
        }
    }
}