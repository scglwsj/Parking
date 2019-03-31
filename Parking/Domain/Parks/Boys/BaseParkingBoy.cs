using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Cars;
using Parking.Domain.Tickets;
using Parking.Exceptions;

namespace Parking.Domain.Parks.Boys
{
    public abstract class BaseParkingBoy
    {
        protected readonly IList<Lot> _parkingLots;

        protected BaseParkingBoy(IList<Lot> parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public Ticket Park(Car car)
        {
            var parkingLot = _parkingLots.FirstOrDefault(pl => pl.UsableParkingSpotNumber > 0);
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
            var parkingLot = _parkingLots.FirstOrDefault(pl => pl.Id == ticket.LotId);
            if (parkingLot == null)
            {
                throw new InvalIDTicketException();
            }

            return parkingLot.GetCar(ticket);
        }

        public IList<Car> GetCars(IEnumerable<Ticket> tickets)
        {
            return tickets.Select(GetCar).ToList();
        }
    }
}