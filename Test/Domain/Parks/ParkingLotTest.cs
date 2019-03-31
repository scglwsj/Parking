using System;
using System.Collections.Generic;
using Parking.Domain.Cars;
using Parking.Domain.Parks;
using Parking.Domain.Tickets;
using Parking.Exceptions;
using Xunit;

namespace ParkingTest.Domain.Parks
{
    public class LotTest
    {
        private Lot _parkingLot;

        [Fact]
        public void Should_get_ticket_when_park_a_car()
        {
            _parkingLot = new Lot(2);
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = _parkingLot.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_tickets_when_park_many_cars()
        {
            _parkingLot = new Lot(2);
            var cars = new List<Car> {new Car("川A 123456"), new Car("川A 234567")};
            var tickets = _parkingLot.Park(cars);

            Assert.Equal(cars.Count, tickets.Count);
        }

        [Fact]
        public void Should_throw_error_when_park_a_car_no_spot()
        {
            _parkingLot = new Lot(0);

            const string carId = "川A 123456";
            var car = new Car(carId);
            Assert.Throws<NoSpotException>(() =>
                _parkingLot.Park(car));
        }

        [Fact]
        public void Should_throw_error_when_park_cars_no_enough_spot()
        {
            _parkingLot = new Lot(1);
            var cars = new List<Car> {new Car("川A 123456"), new Car("川A 234567")};
            Assert.Throws<NoSpotException>(() =>
                _parkingLot.Park(cars));
        }

        [Fact]
        public void Should_get_a_car_when_ticket_is_valID()
        {
            _parkingLot = new Lot(1);
            const string carId = "川A 123456";
            var car = new Car(carId);
            var ticket = _parkingLot.Park(car);
            var getCar = _parkingLot.GetCar(ticket);
            Assert.Equal(carId, getCar.Id);
        }

        [Fact]
        public void Should_get_cars_when_tickets_valID()
        {
            _parkingLot = new Lot(3);
            const string carId1 = "123";
            const string carId2 = "234";
            var tickets = _parkingLot.Park(new List<Car> {new Car(carId1), new Car(carId2)});
            var cars = _parkingLot.GetCars(tickets);

            Assert.Equal(2, cars.Count);
            Assert.Equal(carId1, cars[0].Id);
            Assert.Equal(carId2, cars[1].Id);
        }

        [Fact]
        public void Should_throw_error_when_tickets_invalid()
        {
            _parkingLot = new Lot(1);
            const string carId = "川A 123456";
            var car = new Car(carId);
            _parkingLot.Park(car);
            Assert.Throws<InvalidTicketException>(() =>
                _parkingLot.GetCar(new Ticket(car.Id, Guid.NewGuid().ToString(), _parkingLot.Id)));
        }

        [Fact]
        public void Should_throw_error_when_ticket_used_twice()
        {
            _parkingLot = new Lot(1);
            const string carId = "川A 123456";
            var car = new Car(carId);
            var ticket = _parkingLot.Park(car);
            _parkingLot.GetCar(ticket);
            Assert.Throws<InvalidTicketException>(() => _parkingLot.GetCar(ticket));
        }
    }
}