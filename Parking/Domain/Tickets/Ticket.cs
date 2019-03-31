using System;
using Parking.Domain.Cars;
using Parking.Domain.Parks;

namespace Parking.Domain.Tickets
{
    public class Ticket
    {

        public string Id { get; }
        public string CarId { get; }
        public string SpotIdId { get; }
        public string LotId { get; set; }

        public Ticket(string carId, string parkingSpotId, string parkingLotId)
        {
            Id = Guid.NewGuid().ToString();
            CarId = carId;
            SpotIdId = parkingSpotId;
            LotId = parkingLotId;
        }
    }
}
