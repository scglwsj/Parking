using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Domains.ParkingBoys.Interfaces;
using Parking.Domains.Tickets;
using Parking.Exceptions;
using Parking.ValueObjects;

namespace Parking.Domains.ParkingBoys.Entities
{
    public class Lot : IParkable
    {
        public string Id { get; }

        private readonly IDictionary<string, Car> _parkingSpots;

        public int ParkableNumber
        {
            get { return _parkingSpots.Count(ps => ps.Value == null); }
        }

        public Lot(int size)
        {
            Id = Guid.NewGuid().ToString();
            _parkingSpots = new Dictionary<string, Car>(size);
            for (var i = 0; i < size; i++)
            {
                _parkingSpots.Add(Guid.NewGuid().ToString(), null);
            }
        }

        public IList<ParkInformation> Park(IList<Car> cars)
        {
            return cars.Select(Park).ToList();
        }

        public ParkInformation Park(Car car)
        {
            if (ParkableNumber < 1)
            {
                throw new NoSpotException();
            }

            var parkingSpotId = _parkingSpots.First(ps => ps.Value == null).Key;
            _parkingSpots[parkingSpotId] = car;
            return new ParkInformation(Id, parkingSpotId, car.Id);
        }

        public Car Take(Ticket ticket)
        {
            if (ticket.LotId != Id)
            {
                throw new InvalidTicketException();
            }

            var parkingSpotId = _parkingSpots.FirstOrDefault(ps =>
                ps.Value != null && ps.Value.Id == ticket.CarId && ps.Key == ticket.SpotId).Key;
            if (parkingSpotId == null)
            {
                throw new InvalidTicketException();
            }

            var car = _parkingSpots[parkingSpotId];
            _parkingSpots[parkingSpotId] = null;
            return car;
        }

        public IList<Car> Take(IList<Ticket> tickets)
        {
            return tickets.Select(Take).ToList();
        }
    }
}