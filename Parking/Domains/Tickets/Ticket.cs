using System;

namespace Parking.Domains.Tickets
{
    public class Ticket
    {
        public string Id { get; }
        public string CarId { get; }
        public string SpotId { get; }
        public string LotId { get; set; }

        public Ticket(string carId, string parkingSpotId, string parkingLotId)
        {
            Id = Guid.NewGuid().ToString();
            CarId = carId;
            SpotId = parkingSpotId;
            LotId = parkingLotId;
        }
    }
}
