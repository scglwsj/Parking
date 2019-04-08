using System;

namespace Parking.Domain.Tickets.Repository
{
    public interface ITicketReposotory
    {
        void Save(Ticket ticket);
        Ticket Get(string id);
    }
}
