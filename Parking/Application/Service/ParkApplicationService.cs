using Parking.Domain.ParkingBoys.Interface;
using Parking.ValueObject;

namespace Parking.Application.Service
{
   public class ParkApplicationService
   {
       private readonly IParkable _parkable;

       public ParkApplicationService(IParkable parkable)
       {
           _parkable = parkable;
       }

       public void Park(Car car)
       {
           _parkable.Park(car);
       }
   }
}
