using System.Collections.Generic;
using System.Linq;
using Parking.Domains.ParkingBoys.Interfaces;
using Parking.ValueObjects;

namespace Parking.Domains.ParkingBoys.Entities
{
    public class SmartParkingBoy : BaseParkingBoy, IParkable
    {
        public SmartParkingBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }

        public new ParkInformation Park(Car car)
        {
            var parkingLot = Lots.OrderByDescending(pl => pl.ParkableNumber).First();
            return parkingLot.Park(car);
        }

        public List<ParkInformation> Park(List<Car> cars)
        {
            return cars.Select(Park).ToList();
        }
    }
}