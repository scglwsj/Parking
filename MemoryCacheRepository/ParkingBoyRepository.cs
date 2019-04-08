using System.Collections.Generic;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.ParkingBoys.Repository;
using Parking.ValueObject;

namespace MemoryCacheRepository
{
    public class ParkingBoyRepository : IParkingBoyRepository
    {
        public SmartParkingBoy GetBoy(BoyId boyId)
        {
            return new SmartParkingBoy(new List<Lot> { new Lot(16) });
        }
    }
}
