using System.Collections.Generic;
using System.Linq;
using Parking.Domain.Tickets;
using Parking.Domain.Tickets.Repository;

namespace MemoryCacheRepository
{
    public class TicketRepositpry: ITicketReposotory
    {
        private readonly IList<Ticket> tickets;

        public TicketRepositpry()
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
