using System.Collections.Generic;
using System.Linq;
using Parking.Domain.ParkingBoys.Interface;
using Parking.Domain.Tickets;
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

       public Ticket Park(Car car)
       {
           var parkInformation = _parkable.Park(car);
           return new Ticket(parkInformation);
       }

       public IList<Ticket> Park(IList<Car> cars)
       {
           var informatics = _parkable.Park(cars);
           return informatics.Select(i => new Ticket(i)).ToList();
       }

       public Car Take(Ticket ticket)
       {
           return _parkable.Take(ticket);
       }
   }
}
