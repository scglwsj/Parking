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
        private readonly IParkingBoyRepository _parkingBoyRepository;
        private readonly ITicketReposotory _ticketReposotory;

        public ParkApplicationService(IParkingBoyRepository parkingBoyRepository, ITicketReposotory ticketReposotory)
        {
            _parkingBoyRepository = parkingBoyRepository;
            _ticketReposotory = ticketReposotory;
            var boy = _parkingBoyRepository.GetBoy();
            _parkable = boy;
        }

        public Ticket Park(Car car)
        {
            var parkInformation = _parkable.Park(car);
            var ticket = new Ticket(parkInformation);
            _ticketReposotory.Save(ticket);
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
            return _ticketReposotory.Get(ticketId);
        }
    }
}
