using System.Linq;
using Parking.Domain.Tickets;
using Parking.Domain.Tickets.Repository;
using SqlServerRepository.DataObject;

namespace SqlServerRepository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SqlServerDbContext _db;

        public TicketRepository()
        {
            _db = new SqlServerDbContext();
        }

        public void Save(Ticket ticket)
        {
            _db.Ticket.Add(new TicketDo(ticket));
            _db.SaveChanges();
        }

        public Ticket Get(string id)
        {
            var ticket = _db.Ticket.Single(t => t.Id == id);
            _db.Ticket.Remove(ticket);
            _db.SaveChanges();
            return ticket.Entity;
        }
    }
}