using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Tickets;
using Parking.Domain.Tickets.Repository;

namespace MemoryCacheRepository
{
    public class TicketRepository: ITicketRepository
    {
        private readonly IList<Ticket> tickets;

        public TicketRepository()
        {
            tickets = new List<Ticket>();
        }

        public Ticket Get(string id)
        {
            return tickets.FirstOrDefault(t => t.Id.Equals(id));
        }

        public void Save(Ticket ticket)
        {
            tickets.Add(ticket);
        }
    }
}
