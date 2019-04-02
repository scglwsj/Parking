using Moq;
using Parking.Application.Service;
using Parking.Domain.ParkingBoys.Entity;
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

        [Fact]
        public void Park_should_return_right_ticket()
        {
            var parkableMock = new Mock<IParkable>();
            const string carId = "川A 123456";
            const string lotId = "lot ID";
            const string spotId = "spot ID";
            parkableMock.Setup(pm => pm.Park(It.Is<Car>(c => c.Id.Equals(carId))))
                .Returns(new ParkInformation(lotId, spotId, carId));
            var service = new ParkApplicationService(parkableMock.Object);

            var ticket = service.Park(new Car(carId));

            Assert.Equal(carId, ticket.CarId);
            Assert.Equal(lotId, ticket.LotId);
            Assert.Equal(spotId, ticket.SpotId);
        }
    }
}