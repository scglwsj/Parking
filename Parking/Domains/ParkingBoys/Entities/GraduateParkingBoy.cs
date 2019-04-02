using System.Collections.Generic;

namespace Parking.Domains.ParkingBoys.Entities
{
    public class GraduateBoy : BaseParkingBoy
    {
        public GraduateBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }
    }
}