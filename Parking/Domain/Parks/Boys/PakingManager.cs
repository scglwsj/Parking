using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Tickets;
using Parking.ValueObject;

namespace Parking.Domain.Parks.Boys
{
    public class PakingManager : BaseParkingBoy
    {
        private readonly IList<BaseParkingBoy> _parkingBoys;

        public PakingManager(IList<Lot> parkingLots) : base(parkingLots)
        {
        }

        public PakingManager(IList<Lot> parkingLots, IList<BaseParkingBoy> boys) : this(parkingLots)
        {
            _parkingBoys = boys;
        }

        public new Ticket Park(Car car)
        {
            if (_parkingBoys == null)
            {
                return base.Park(car);
            }

            var boy = _parkingBoys.FirstOrDefault(pb => pb.IsEmpty);
            if (boy == null)
            {
                return base.Park(car);
            }
            else
            {
                return boy.Park(car);
            }
        }
    }
}
