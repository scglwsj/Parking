using System.Collections.Generic;
using System.Linq;
using Parking.Domain.ParkingBoys.Entity;
using Parking.Domain.ParkingBoys.Interface;
using Parking.Domain.ParkingBoys.Repository;
using Parking.Domain.Tickets;
using Parking.Domain.Tickets.Repository;
using Parking.ValueObject;

namespace Parking.Application.Service
{
    public class ParkApplicationService
    {
        private readonly IParkable _parkable;
        private readonly ITicketRepository _ticketRepository;

        public ParkApplicationService(IParkingBoyRepository parkingBoyRepository, ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            var boy = parkingBoyRepository.GetBoy(new BoyId("26C3719E-984E-4E47-B5D4-D7A5633FEE72"));
            _parkable = boy;
        }

        public Ticket Park(Car car)
        {
            var parkInformation = _parkable.Park(car);
            var ticket = new Ticket(parkInformation);
            _ticketRepository.Save(ticket);
            return ticket;
        }

        public IList<Ticket> Park(IList<Car> cars)
        {
            var informatics = _parkable.Park(cars);
            return informatics.Select(i => new Ticket(i)).ToList();
        }

        public Car Take(Ticket ticket)
        {
            return _parkable.Take(ticket);
        }

        public IList<Car> Take(IList<Ticket> tickets)
        {
            return _parkable.Take(tickets);
        }

        public SmartParkingBoy GetBoy()
        {
            return _parkable as SmartParkingBoy;
        }

        public Ticket FindTicket(string ticketId)
        {
            return _ticketRepository.Get(ticketId);
        }
    }
}
