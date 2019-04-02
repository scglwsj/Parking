using System;
using Parking.Domain.ParkingBoys.Entity;

namespace Parking.Domain.Tickets
{
    public class Ticket
    {
        public string Id { get; }
        public string CarId { get; }
        public string SpotId { get; }
        public string LotId { get; }

        public Ticket(ParkInformation parkInformation)
        {
            if (parkInformation == null)
            {
                return;
            }

            Id = Guid.NewGuid().ToString();
            CarId = parkInformation.CarId;
            SpotId = parkInformation.SpotId;
            LotId = parkInformation.LotId;
        }
    }
}