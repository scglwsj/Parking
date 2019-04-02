using System.Collections.Generic;

namespace Parking.Domain.ParkingBoys.Entity
{
    public class GraduateBoy : BaseParkingBoy
    {
        public GraduateBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }
    }
}