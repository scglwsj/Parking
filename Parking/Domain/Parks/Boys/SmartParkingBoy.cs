using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Cars;
using Parking.Domain.Tickets;

namespace Parking.Domain.Parks.Boys
{
    public class SmartParkingBoy : BaseParkingBoy
    {
        public SmartParkingBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }

        public new Ticket Park(Car car)
        {
            var parkingLot = _parkingLots.OrderByDescending(pl => pl.UsableParkingSpotNumber).First();
            return parkingLot.Park(car);
        }
    }
}