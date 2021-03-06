﻿using System.Linq;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.ParkingBoys.Repository;
using Parking.ValueObject;
using SqlServerRepository.DataObject;

namespace SqlServerRepository
{
    public class ParkingBoyRepository : IParkingBoyRepository
    {
        private readonly SqlServerDbContext _db;
        private static SmartParkingBoy _boy;

        public ParkingBoyRepository()
        {
            _db = new SqlServerDbContext();
        }

        public SmartParkingBoy GetBoy(BoyId boyId)
        {
            if (_boy != null) return _boy;
            var boy = _db.Boy.Single(b => b.Id == boyId.Id);
            var lots = _db.BoyLot.Where(bl => bl.BoyId == boy.Id).ToList().Select(lot =>
                    new Lot(lot.LotId,
                        _db.LotSpot.Where(ls => ls.LotId == lot.LotId).Select(ls => ls.SpotId).ToList()))
                .ToList();

            _boy = new SmartParkingBoy(new BoyId(boy.Id), lots);

            return _boy;
        }
    }
}