using System.Collections.Generic;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.ParkingBoys.Repository;

namespace MemoryCacheRepository
{
    public class ParkingBoyRepository : IParkingBoyRepository
    {
        public SmartParkingBoy GetBoy()
        {
            return new SmartParkingBoy(new List<Lot> { new Lot(16) });
        }
    }
}
