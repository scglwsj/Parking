using System.Collections.Generic;

namespace Parking.Domain.ParkingBoys.Entities
{
    public class GraduateBoy : BaseParkingBoy
    {
        public GraduateBoy(IList<Lot> parkingLots) : base(parkingLots)
        {
        }
    }
}