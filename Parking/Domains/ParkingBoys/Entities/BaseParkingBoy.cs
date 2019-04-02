using System.Collections.Generic;
using System.Linq;
using Parking.Domains.ParkingBoys.Interfaces;
using Parking.Domains.Tickets;
using Parking.Exceptions;
using Parking.ValueObjects;

namespace Parking.Domains.ParkingBoys.Entities
{
    public abstract class BaseParkingBoy: IParkable
    {
        protected readonly IList<Lot> Lots;

        protected BaseParkingBoy(IList<Lot> parkingLots)
        {
            Lots = parkingLots;
        }

        public int ParkableNumber
        {
            get { return Lots.Sum(lot => lot.ParkableNumber); }
        }

        public ParkInformation Park(Car car)
        {
            var parkingLot = Lots.FirstOrDefault(pl => pl.ParkableNumber > 0);
            if (parkingLot == null)
            {
                throw new NoSpotException();
            }

            return parkingLot.Park(car);
        }

        public IList<ParkInformation> Park(IList<Car> cars)
        {
            return cars.Select(Park).ToList();
        }

        public Car Take(Ticket ticket)
        {
            var parkingLot = Lots.FirstOrDefault(pl => pl.Id == ticket.LotId);
            if (parkingLot == null)
            {
                throw new InvalidTicketException();
            }

            return parkingLot.Take(ticket);
        }

        public IList<Car> Take(IList<Ticket> tickets)
        {
            return tickets.Select(Take).ToList();
        }
    }
}