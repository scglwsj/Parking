using System.Collections.Generic;
using Parking.Domains.Tickets;
using Parking.ValueObjects;

namespace Parking.Domains.ParkingBoys.Interfaces
{
    public interface IParkable
    {
        int ParkableNumber { get; }

        ParkInformation Park(Car car);
        IList<ParkInformation> Park(IList<Car> cars);
        Car Take(Ticket ticket);
        IList<Car> Take(IList<Ticket> tickets);
    }

    public class ParkInformation
    {
        public ParkInformation(string lotId, string spotId, string carId)
        {
            LotId = lotId;
            SpotId = spotId;
            CarId = carId;
        }

        public string CarId { get; }
        public string SpotId { get; }
        public string LotId { get; }
    }
}