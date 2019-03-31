using System.Collections.Generic;
using Parking.Domain.Cars;
using Parking.Domain.Parks;
using Parking.Domain.Parks.Boys;
using Xunit;

namespace ParkingTest.Domain.Parks
{
public    class SmartParkingBoyTest
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
    }
}
