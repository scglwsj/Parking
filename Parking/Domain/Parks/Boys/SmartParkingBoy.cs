using System.Collections.Generic;

namespace Parking.Domain.Parks.Boys
{
    public class SmartParkingBoy : BaseParkingBoy
    {
        public SmartParkingBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }
    }
}