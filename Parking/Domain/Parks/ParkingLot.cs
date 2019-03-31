using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Tickets;
using Parking.Exceptions;
using Parking.ValueObject;

namespace Parking.Domain.Parks
{
    public class Lot
    {
        private readonly IDictionary<string, Car> _parkingSpots;
        public int UsableParkingSpotNumber
        {
            get { return _parkingSpots.Count(ps => ps.Value == null); }
        }

        public string Id { get; }

        public Lot(int size)
        {
            Id = Guid.NewGuid().ToString();

            _parkingSpots = new Dictionary<string, Car>(size);

            for (var i = 0; i < size; i++)
            {
                _parkingSpots.Add(Guid.NewGuid().ToString(), null);
            }
        }

        public Ticket Park(Car car)
        {
            if (UsableParkingSpotNumber < 1)
            {
                throw new NoSpotException();
            }

            var parkingSpotId = _parkingSpots.First(ps => ps.Value == null).Key;
            _parkingSpots[parkingSpotId] = car;
            return new Ticket(car.Id, parkingSpotId, Id);
        }

        public IList<Ticket> Park(IList<Car> cars)
        {
            if (UsableParkingSpotNumber < cars.Count)
            {
                throw new NoSpotException();
            }

            return cars.Select(Park).ToList();
        }

        public Car GetCar(Ticket ticket)
        {
            if (ticket.LotId != Id)
            {
                throw new InvalidTicketException();
            }

            var parkingSpotId = _parkingSpots.FirstOrDefault(ps =>
                ps.Value != null && ps.Value.Id == ticket.CarId && ps.Key == ticket.SpotIdId).Key;
            if (parkingSpotId == null)
            {
                throw new InvalidTicketException();
            }

            var car = _parkingSpots[parkingSpotId];
            _parkingSpots[parkingSpotId] = null;
            return car;
        }

        public IList<Car> GetCars(IEnumerable<Ticket> tickets)
        {
            return tickets.Select(GetCar).ToList();
        }
    }
}