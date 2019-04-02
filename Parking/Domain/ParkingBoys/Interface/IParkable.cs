using System.Collections.Generic;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.Tickets;
using Parking.ValueObject;

namespace Parking.Domain.ParkingBoys.Interface
{
    public interface IParkable
    {
        int ParkableNumber { get; }

        ParkInformation Park(Car car);
        IList<ParkInformation> Park(IList<Car> cars);
        Car Take(Ticket ticket);
        IList<Car> Take(IList<Ticket> tickets);
    }
}