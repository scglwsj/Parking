using System;
using Parking.Domains.ParkingBoys.Interfaces;

namespace Parking.Domains.Tickets
{
    public class Ticket
    {
        public string Id { get; }
        public string CarId { get; }
        public string SpotId { get; }
        public string LotId { get; }

        public Ticket(string carId, string parkingSpotId, string parkingLotId)
        {
            Id = Guid.NewGuid().ToString();
            CarId = carId;
            SpotId = parkingSpotId;
            LotId = parkingLotId;
        }

        public Ticket(ParkInformation parkInformation)
        {
            Id = Guid.NewGuid().ToString();
            CarId = parkInformation.CarId;
            SpotId = parkInformation.SpotId;
            LotId = parkInformation.LotId;
        }
    }
}