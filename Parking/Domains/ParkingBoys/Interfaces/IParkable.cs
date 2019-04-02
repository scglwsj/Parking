using System.Collections.Generic;
using Parking.Domains.ParkingBoys.Entities;
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
}