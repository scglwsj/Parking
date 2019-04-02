namespace Parking.Domain.ParkingBoys.Entity
{
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