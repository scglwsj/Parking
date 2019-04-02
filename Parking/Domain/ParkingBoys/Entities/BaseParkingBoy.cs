using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Tickets;
using Parking.Exceptions;
using Parking.ValueObject;

namespace Parking.Domain.ParkingBoys.Entities
{
    public abstract class BaseParkingBoy
    {
        protected readonly IList<Lot> Lots;

        protected BaseParkingBoy(IList<Lot> parkingLots)
        {
            Lots = parkingLots;
        }

        public bool IsEmpty
        {
            get { return Lots.Any(pl => pl.UsableParkingSpotNumber > 0); }
        }

        public Ticket Park(Car car)
        {
            var parkingLot = Lots.FirstOrDefault(pl => pl.UsableParkingSpotNumber > 0);
            if (parkingLot == null)
            {
                throw new NoSpotException();
            }

            return parkingLot.Park(car);
        }

        public IList<Ticket> Park(IEnumerable<Car> cars)
        {
            return cars.Select(Park).ToList();
        }

        public Car GetCar(Ticket ticket)
        {
            var parkingLot = Lots.FirstOrDefault(pl => pl.Id == ticket.LotId);
            if (parkingLot == null)
            {
                throw new InvalidTicketException();
            }

            return parkingLot.GetCar(ticket);
        }

        public IList<Car> GetCars(IEnumerable<Ticket> tickets)
        {
            return tickets.Select(GetCar).ToList();
        }
    }
}