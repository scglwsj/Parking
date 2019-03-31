using System;
using System.Collections.Generic;

namespace Parking
{
    public class Ticket
    {

        public string Id { get; }
        public string CarId { get; }
        public string ParkingSpotId { get; }
        public string ParkingLotId { get; set; }

        public Ticket(Car car, ParkingSpot parkingSpot, ParkingLot parkingLot)
        {
            Id = Guid.NewGuid().ToString();
            CarId = car.Id;
            ParkingSpotId = parkingSpot.Id;
            ParkingLotId = parkingLot.Id;
        }
    }
}
