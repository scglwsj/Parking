using System.Collections.Generic;

namespace Parking.Domain.Parks.Boys
{
    public class GraduateBoy:BaseParkingBoy
    {
        public GraduateBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }
    }
}