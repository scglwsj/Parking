using System;
using System.Collections.Generic;
using Parking.Domain.Parks;
using Parking.Domain.Parks.Boys;
using Parking.Exceptions;
using Parking.ValueObject;
using Xunit;

namespace ParkingTest.Domain.Parks
{
    public class PakingManagerTest
    {
        [Fact]
        public void Should_return_a_ticket_from_my_lot()
        {
            var lot = new Lot(1);
            var pakingManager = new PakingManager(new List<Lot> { lot });
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = pakingManager.Park(car);

            Assert.Equal(lot.Id, ticket.LotId);
        }

        [Fact]
        public void Should_return_ticket_from_lot_of_boy()
        {
            var lot = new Lot(1);
            var boy = new GraduateBoy(new List<Lot> { lot });
            var pakingManager = new PakingManager(new List<Lot>(), new List<BaseParkingBoy> { boy });
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = pakingManager.Park(car);

            Assert.Equal(lot.Id, ticket.LotId);
        }

        [Fact]
        public void Should_return_ticket_from_lot_of_boy_when_we_both_have_a_lot()
        {
            var lot = new Lot(1);
            var boy = new GraduateBoy(new List<Lot> { lot });
            var pakingManager = new PakingManager(new List<Lot> { new Lot(1) }, new List<BaseParkingBoy> { boy });
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = pakingManager.Park(car);

            Assert.Equal(lot.Id, ticket.LotId);
        }

        [Fact]
        public void Shoul_return_ticket_from_my_lot_when_we_both_have_a_lot_but_boys_is_full()
        {
            var lot = new Lot(1);
            var boy = new GraduateBoy(new List<Lot> { new Lot(0) });
            var pakingManager = new PakingManager(new List<Lot> { lot }, new List<BaseParkingBoy> { boy });
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = pakingManager.Park(car);

            Assert.Equal(lot.Id, ticket.LotId);
        }

        [Fact]
        public void Should_return_ticket_from_empty_lot_of_boy_when_boy_have_both_full_and_empty_lot()
        {
            var myLot = new Lot(1);
            var emptyLot = new Lot(1);
            var boysLots = new List<Lot> { new Lot(0), emptyLot };
            var boy = new GraduateBoy(boysLots);
            var pakingManager = new PakingManager(new List<Lot> { myLot }, new List<BaseParkingBoy> { boy });
            const string carId = "川A 123456";
            var car = new Car(carId);

            var ticket = pakingManager.Park(car);

            Assert.Equal(emptyLot.Id, ticket.LotId);
        }

        [Fact]
        public void Should_throw_error_when_my_lot_is_full_and_no_boy()
        {
            var pakingManager = new PakingManager(new List<Lot> { new Lot(0) });
            const string carId = "川A 123456";
            var car = new Car(carId);

            Assert.Throws<NoSpotException>(() =>
            pakingManager.Park(car));
        }
    }
}
