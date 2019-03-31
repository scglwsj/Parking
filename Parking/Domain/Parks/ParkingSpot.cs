using System;
using Parking.Domain.Cars;

namespace Parking.Domain.Parks
{
    public class Spot
    {
        public Spot()
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