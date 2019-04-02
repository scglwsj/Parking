using System.Collections.Generic;
using System.Linq;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.Tickets;
using Parking.Exceptions;
using Parking.ValueObject;
using Xunit;

namespace ParkingTest.Domain.ParkingBoys
{
    public class BoyTest
    {
        private GraduateBoy _graduateParkingBoy;

        [Fact]
        public void Should_get_ticket_when_parking_boy_park_a_car()
        {
            _graduateParkingBoy = new GraduateBoy(new List<Lot> {new Lot(1)});
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = _graduateParkingBoy.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_tickets_when_parking_boy_park_many_cars()
        {
            _graduateParkingBoy = new GraduateBoy(new List<Lot> {new Lot(2)});
            var cars = new List<Car> {new Car("123"), new Car("234")};

            var tickets = _graduateParkingBoy.Park(cars);

            Assert.Equal(cars.Count, tickets.Count);
        }

        [Fact]
        public void Should_throw_error_when_parking_boy_park_a_car_and_park_lot_not_have_enough_plot()
        {
            _graduateParkingBoy = new GraduateBoy(new List<Lot> {new Lot(0)});
            const string carId = "川A 123456";
            var car = new Car(carId);

            Assert.Throws<NoEnoughSpotException>(() =>
                _graduateParkingBoy.Park(car));
        }

        [Fact]
        public void Should_return_tickets_when_parking_boy_park_many_cars_in_different_parking_lot()
        {
            _graduateParkingBoy = new GraduateBoy(new List<Lot> {new Lot(1), new Lot(2)});
            const string carId1 = "123";
            const string carId2 = "234";

            var tickets = _graduateParkingBoy.Park(new List<Car> {new Car(carId1), new Car(carId2)});

            Assert.Equal(2, tickets.Count);
            Assert.NotEqual(tickets[0].LotId, tickets[1].LotId);
            Assert.Equal(carId1, tickets[0].CarId);
            Assert.Equal(carId2, tickets[1].CarId);
        }

        [Fact]
        public void Should_return_car_when_get_car_when_ticket_is_valID()
        {
            _graduateParkingBoy = new GraduateBoy(new List<Lot> {new Lot(1)});
            const string carId = "川A 123456";
            var car = new Car(carId);
            var ticket = new Ticket(_graduateParkingBoy.Park(car));

            var getCar = _graduateParkingBoy.Take(ticket);

            Assert.Equal(carId, getCar.Id);
        }

        [Fact]
        public void
            Should_return_cars_when_parking_boy_park_many_cars_in_different_parking_lot_and_get_them_by_tickets()
        {
            _graduateParkingBoy = new GraduateBoy(new List<Lot> {new Lot(1), new Lot(2)});
            const string carId1 = "123";
            const string carId2 = "234";
            var tickets = _graduateParkingBoy.Park(new List<Car> {new Car(carId1), new Car(carId2)})
                .Select(pi => new Ticket(pi)).ToList();

            var cars = _graduateParkingBoy.Take(tickets);

            Assert.Equal(2, cars.Count);
            Assert.Equal(carId1, cars[0].Id);
            Assert.Equal(carId2, cars[1].Id);
        }
    }
}