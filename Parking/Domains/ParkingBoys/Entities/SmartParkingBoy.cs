using System.Collections.Generic;
using System.Linq;
using Parking.Domains.Tickets;
using Parking.ValueObjects;

namespace Parking.Domains.ParkingBoys.Entities
{
    public class SmartParkingBoy : BaseParkingBoy
    {
        public SmartParkingBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }

        public new Ticket Park(Car car)
        {
            var parkingLot = Lots.OrderByDescending(pl => pl.UsableParkingSpotNumber).First();
            return parkingLot.Park(car);
        }

        public List<Ticket> Park(List<Car> cars)
        {
            return cars.Select(Park).ToList();
        }
    }
}