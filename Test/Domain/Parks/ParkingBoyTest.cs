using System.Collections.Generic;
using Parking.Domain.Cars;
using Parking.Domain.Parks;
using Parking.Exceptions;
using Xunit;

namespace ParkingTest.Domain.Parks
{
    public class BoyTest
    {
        private Boy _parkingBoy;

        [Fact]
        public void Should_get_ticket_when_parking_boy_park_a_car()
        {
            _parkingBoy = new Boy(new List<int> {1});
            const string carId = "川A 123456";
            var car = new Car(carId);
            var ticket = _parkingBoy.Park(car);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_tickets_when_parking_boy_park_many_cars()
        {
            _parkingBoy = new Boy(new List<int> {2});
            var cars = new List<Car> {new Car("123"), new Car("234")};
            var tickets = _parkingBoy.Park(cars);
            Assert.Equal(cars.Count, tickets.Count);
        }

        [Fact]
        public void Should_throw_error_when_parking_boy_park_a_car_and_park_lot_not_have_enough_plot()
        {
            _parkingBoy = new Boy(new List<int> {0});
            const string carId = "川A 123456";
            var car = new Car(carId);
            Assert.Throws<NoSpotException>(() => _parkingBoy.Park(car));
        }

        [Fact]
        public void Should_return_tickets_when_parking_boy_park_many_cars_in_different_parking_lot()
        {
            _parkingBoy = new Boy(new List<int> {1, 2});
            const string carId1 = "123";
            const string carId2 = "234";
            var tickets = _parkingBoy.Park(new List<Car> {new Car(carId1), new Car(carId2)});
            Assert.Equal(2, tickets.Count);
            Assert.NotEqual(tickets[0].LotId, tickets[1].LotId);
            Assert.Equal(carId1, tickets[0].CarId);
            Assert.Equal(carId2, tickets[1].CarId);
        }

        [Fact]
        public void Should_return_car_when_get_car_when_ticket_is_valID()
        {
            _parkingBoy = new Boy(new List<int> {1});
            const string carId = "川A 123456";
            var car = new Car(carId);
            var ticket = _parkingBoy.Park(car);
            var getCar = _parkingBoy.GetCar(ticket);
            Assert.Equal(carId, getCar.Id);
        }

        [Fact]
        public void
            Should_return_cars_when_parking_boy_park_many_cars_in_different_parking_lot_and_get_them_by_tickets()
        {
            _parkingBoy = new Boy(new List<int> {1, 2});
            const string carId1 = "123";
            const string carId2 = "234";
            var tickets = _parkingBoy.Park(new List<Car> {new Car(carId1), new Car(carId2)});
            var cars = _parkingBoy.GetCars(tickets);
            Assert.Equal(2, cars.Count);
            Assert.Equal(carId1, cars[0].Id);
            Assert.Equal(carId2, cars[1].Id);
        }
    }
}