using System.Collections.Generic;
using Parking.Domain.Cars;
using Parking.Domain.Parks;
using Parking.Domain.Parks.Boys;
using Xunit;

namespace ParkingTest.Domain.Parks
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_get_ticket_when_parking_boy_park_a_car()
        {
            var boy = new SmartParkingBoy(new List<Lot> {new Lot(1)});
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = boy.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_ticket_from_lot_1_when_smart_boy_park_and_park_1_is_more_empty_than_lot_2()
        {
            var lot1 = new Lot(2);
            var lot2 = new Lot(1);
            var boy = new SmartParkingBoy(new List<Lot> {lot1, lot2});
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = boy.Park(car);

            Assert.Equal(lot1.Id, ticket.LotId);
        }

        [Fact]
        public void Should_get_ticket_from_lot_2_when_smart_boy_park_and_park_2_is_more_empty_than_lot_1()
        {
            var lot1 = new Lot(1);
            var lot2 = new Lot(2);
            var boy = new SmartParkingBoy(new List<Lot> { lot1, lot2 });
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = boy.Park(car);

            Assert.Equal(lot2.Id, ticket.LotId);
        }
    }
}