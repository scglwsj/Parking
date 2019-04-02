using System.Collections.Generic;
using Moq;
using Parking.Application.Service;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.ParkingBoys.Interface;
using Parking.Domain.Tickets;
using Parking.ValueObject;
using Xunit;

namespace ParkingTest.Application.Service
{
    public class ParkApplicationServiceTest
    {
        private readonly Mock<IParkable> _parkableMock;
        private ParkApplicationService _service;

        public ParkApplicationServiceTest()
        {
            _parkableMock = new Mock<IParkable>();
        }

        [Fact]
        public void Park_should_park_by_parkableMock()
        {
            _service = new ParkApplicationService(_parkableMock.Object);
            var car = new Car("川A 123456");

            _service.Park(car);

            _parkableMock.Verify(pm => pm.Park(car), Times.Once);
        }

        [Fact]
        public void Park_should_return_right_ticket()
        {
            const string carId = "川A 123456";
            const string lotId = "lot ID";
            const string spotId = "spot ID";
            _parkableMock.Setup(pm => pm.Park(It.Is<Car>(c => c.Id.Equals(carId))))
                .Returns(new ParkInformation(lotId, spotId, carId));
            var service = new ParkApplicationService(_parkableMock.Object);

            var ticket = service.Park(new Car(carId));

            Assert.Equal(carId, ticket.CarId);
            Assert.Equal(lotId, ticket.LotId);
            Assert.Equal(spotId, ticket.SpotId);
        }

        [Fact]
        public void Park_cars_should_return_right_tickets()
        {
            const string carId1 = "川A 123456";
            const string carId2 = "川A 234567";
            const string lotId = "lot ID";
            const string spotId = "spot ID";
            var cars = new List<Car> {new Car(carId1), new Car(carId2)};
            _parkableMock.Setup(pm => pm.Park(cars)).Returns(new List<ParkInformation>
                {new ParkInformation(lotId, spotId, carId1), new ParkInformation(lotId, spotId, carId2)});
             _service = new ParkApplicationService(_parkableMock.Object);

            var tickets = _service.Park(cars);

            Assert.Equal(cars.Count, tickets.Count);
            Assert.Equal(carId1, tickets[0].CarId);
            Assert.Equal(carId2, tickets[1].CarId);
        }

        [Fact]
        public void Take_should_return_car()
        {
            var car = new Car("川A 123456");
            var ticket = new Ticket(new ParkInformation("lot ID", "spot ID", car.Id));
            _parkableMock.Setup(pm => pm.Take(ticket)).Returns(car);
             _service = new ParkApplicationService(_parkableMock.Object);

            var takeCar = _service.Take(ticket);

            Assert.Equal(car.Id, takeCar.Id);
        }
    }
}