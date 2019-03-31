using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Exceptions;

namespace Parking
{
    public class ParkingLot
    {
        readonly List<ParkingSpot> parkingSpots;
        //readonly Dictionary<string, Car> parkingSpots;
        public int UsableParkingSpotNumber { get { return parkingSpots.Count(ps => ps.ParkingCar == null); } }
        public string Id { get; }

        public ParkingLot(int size)
        {
            Id = Guid.NewGuid().ToString();

            parkingSpots = new List<ParkingSpot>(size);

            for (int i = 0; i < size; i++)
            {
                parkingSpots.Add(new ParkingSpot());
            }
        }

        public Ticket Park(Car car)
        {
            if (UsableParkingSpotNumber < 1)
            {
                throw new NoSpotException();
            }

            var parkingSpot = parkingSpots.First(ps => ps.ParkingCar == null);
            parkingSpot.Park(car);
            return new Ticket(car, parkingSpot, this);
        }

        public List<Ticket> Park(List<Car> cars)
        {
            if (UsableParkingSpotNumber < cars.Count)
            {
                throw new NoSpotException();
            }

            return cars.Select(Park).ToList();
        }

        public Car GetCar(Ticket ticket)
        {
            if(ticket.ParkingLotId!=Id){
                throw new InvalidTicketException();
            }

            var parkingSpot = parkingSpots.FirstOrDefault(ps => ps.ParkingCar != null && ps.ParkingCar.Id == ticket.CarId && ps.Id == ticket.ParkingSpotId);
            if (parkingSpot == null)
            {
                throw new InvalidTicketException();
            }
            return parkingSpot.GetCar();
        }

        public List<Car> GetCars(List<Ticket> tickets)
        {
            return tickets.Select(GetCar).ToList();
        }
    }
}
