using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Domain.ParkingBoys.Interface;
using Parking.Domain.Tickets;
using Parking.Exceptions;
using Parking.ValueObject;

namespace Parking.Domain.ParkingBoys.Entity
{
    public abstract class BaseParkingBoy : IParkable, IEntity, IEquatable<BaseParkingBoy>
    {
        protected readonly IList<Lot> Lots;

        protected BoyId Id { get; }

        protected BaseParkingBoy(IList<Lot> parkingLots)
        {
            Id = new BoyId();
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
                throw new NoEnoughSpotException();
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

        public override bool Equals(object obj)
        {
            return obj is BaseParkingBoy boy &&
                   EqualityComparer<BoyId>.Default.Equals(Id, boy.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public bool Equals(BaseParkingBoy other)
        {
            return Id == other.Id;
        }

        public static bool operator ==(BaseParkingBoy left, BaseParkingBoy right)
        {
            return EqualityComparer<BoyId>.Default.Equals(left.Id, right.Id);
        }

        public static bool operator !=(BaseParkingBoy left, BaseParkingBoy right)
        {
            return !(left == right);
        }
    }
}