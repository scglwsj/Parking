using Parking.Domain.ParkingBoys.Entity;
using Parking.ValueObject;

namespace Parking.Domain.ParkingBoys.Repository
{
    public interface IParkingBoyRepository
    {
        SmartParkingBoy GetBoy(BoyId boyId);
    }
}
