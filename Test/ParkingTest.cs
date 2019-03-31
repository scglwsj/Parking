using System;
using System.Collections.Generic;
using Parking;
using Parking.Exceptions;
using Xunit;

namespace Test
{
    public class ParkingTest
    {
        private ParkingLot parkingLot;
        private ParkingBoy parkingBoy;
        public ParkingTest()
        {
        }

        [Fact]
        public void Should_get_ticket_when_park_a_car()
        {
            parkingLot = new ParkingLot(2);
            var carId = "川A 123456";
            var car = new Car(carId);

            Ticket ticket = parkingLot.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_tickets_when_park_many_cars()
        {
            parkingLot = new ParkingLot(2);
            var cars = new List<Car> { new Car("川A 123456"), new Car("川A 234567") };
            List<Ticket> tickets = parkingLot.Park(cars);

            Assert.Equal(2, tickets.Count);
        }

        [Fact]
        public void Shold_throw_error_when_park_a_car_no_spot()
        {
            parkingLot = new ParkingLot(0);

            var carId = "川A 123456";
            Car car = new Car(carId);
            Assert.Throws<NoSpotException>(() => parkingLot.Park(car));
        }

        [Fact]
        public void Should_throw_error_when_park_cars_no_enough_spot()
        {
            parkingLot = new ParkingLot(1);
            var cars = new List<Car> { new Car("川A 123456"), new Car("川A 234567") };
            Assert.Throws<NoSpotException>(() => parkingLot.Park(cars));
        }

        [Fact]
        public void Should_get_a_car_when_ticket_is_valid()
        {
            parkingLot = new ParkingLot(1);
            var carId = "川A 123456";
            var car = new Car(carId);
            var ticket = parkingLot.Park(car);
            var getCar = parkingLot.GetCar(ticket);
            Assert.Equal(carId, getCar.Id);
        }

        [Fact]
        public void Should_get_cars_when_tickets_valid()
        {
            parkingLot = new ParkingLot(3);
            var tickets = parkingLot.Park(new List<Car> { new Car("123"), new Car("234") });
            var cars = parkingLot.GetCars(tickets);

            Assert.Equal(2, cars.Count);
            Assert.Equal("123", cars[0].Id);
            Assert.Equal("234", cars[1].Id);
        }

        [Fact]
        public void Should_throw_eroor_when_tickets_invalid()
        {
            parkingLot = new ParkingLot(1);
            var carId = "川A 123456";
            var car = new Car(carId);
            parkingLot.Park(car);
            Assert.Throws<InvalidTicketException>(() => parkingLot.GetCar(new Ticket(new Car("川A 123456"), new ParkingSpot(), parkingLot)));
        }

        [Fact]
        public void Should_throw_eroor_when_ticket_used_twice()
        {
            parkingLot = new ParkingLot(1);
            var carId = "川A 123456";
            var car = new Car(carId);
            var ticket = parkingLot.Park(car);
            parkingLot.GetCar(ticket);
            Assert.Throws<InvalidTicketException>(() => parkingLot.GetCar(ticket));
        }

        [Fact]
        public void Shold_get_ticket_when_parking_boy_park_a_car()
        {
            parkingBoy = new ParkingBoy(new List<int> { 1 });
            var carId = "川A 123456";
            var car = new Car(carId);
            Ticket ticket = parkingBoy.Park(car);
            Assert.NotNull(ticket);
        }
        [Fact]
        public void Should_get_tickets_when_parking_boy_park_many_cars()
        {
            parkingBoy = new ParkingBoy(new List<int> { 2 });
            var tickets = parkingBoy.Park(new List<Car> { new Car("123"), new Car("234") });
            Assert.Equal(2, tickets.Count);
        }

        [Fact]
        public void Shoud_throw_error_when_parking_boy_park_a_car_and_park_lot_not_have_enough_plot()
        {
            parkingBoy = new ParkingBoy(new List<int> { 0 });
            var carId = "川A 123456";
            var car = new Car(carId);
            Assert.Throws<NoSpotException>(() => parkingBoy.Park(car));
        }

        [Fact]
        public void Should_return_tickets_when_parking_boy_park_many_cars_in_different_parking_lot()
        {
            parkingBoy = new ParkingBoy(new List<int> { 1, 2 });
            var tickets = parkingBoy.Park(new List<Car> { new Car("123"), new Car("234") });
            Assert.Equal(2, tickets.Count);
            Assert.NotEqual(tickets[0].ParkingLotId, tickets[1].ParkingLotId);
            Assert.Equal("123", tickets[0].CarId);
            Assert.Equal("234", tickets[1].CarId);
        }

        [Fact]
        public void Should_return_car_when_get_car_when_ticket_is_valid()
        {
            parkingBoy = new ParkingBoy(new List<int> { 1 });
            var carId = "川A 123456";
            var car = new Car(carId);
            var ticket = parkingBoy.Park(car);
            var getCar = parkingBoy.GetCar(ticket);
            Assert.Equal(carId, getCar.Id);
        }

        [Fact]
        public void Should_return_cars_when_parking_boy_park_many_cars_in_different_parking_lot_and_get_them_by_tickets()
        {
            parkingBoy = new ParkingBoy(new List<int> { 1, 2 });
            var tickets = parkingBoy.Park(new List<Car> { new Car("123"), new Car("234") });
            var cars = parkingBoy.GetCars(tickets);
            Assert.Equal(2, cars.Count);
            Assert.Equal("123", cars[0].Id);
            Assert.Equal("234", cars[1].Id);
        }
    }
}
