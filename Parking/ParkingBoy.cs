using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Exceptions;

namespace Parking
{
    public class ParkingBoy
    {
        List<ParkingLot> parkingLots;

        public ParkingBoy(List<int> sizes)
        {
            parkingLots = sizes.Select(size => new ParkingLot(size)).ToList();
        }

        public Ticket Park(Car car)
        {
            var parkingLot = parkingLots.FirstOrDefault(pl => pl.UsableParkingSpotNumber > 0);
            if (parkingLot == null)
            {
                throw new NoSpotException();
            }
            return parkingLot.Park(car);
        }

        public List<Ticket> Park(List<Car> cars)
        {
            return cars.Select(Park).ToList();
        }

        public Car GetCar(Ticket ticket)
        {
            var parkingLot = parkingLots.FirstOrDefault(pl => pl.Id==ticket.ParkingLotId);
            if(parkingLot==null){
                throw new InvalidTicketException();
            }
            return  parkingLot.GetCar(ticket);
        }

        public List<Car> GetCars(List<Ticket> tickets)
        {
            return tickets.Select(GetCar).ToList();
        }
    }
}
