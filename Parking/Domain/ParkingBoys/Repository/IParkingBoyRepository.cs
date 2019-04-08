using System;

using Parking.Domain.ParkingBoys.Entity;

namespace Parking.Domain.ParkingBoys.Repository
{
    public interface IParkingBoyRepository
    {
        SmartParkingBoy GetBoy();
    }
}
