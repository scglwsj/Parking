using System;

namespace Parking
{
    public class ParkingSpot
    {
        public ParkingSpot()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
        public Car ParkingCar { get; private set; }

        public void Park(Car car)
        {
            ParkingCar = car;
        }

        internal Car GetCar()
        {
            var car = ParkingCar;
            ParkingCar = null;
            return car;
        }
    }
}
