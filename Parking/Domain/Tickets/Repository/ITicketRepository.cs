namespace Parking.Domain.Tickets.Repository
{
    public interface ITicketRepository
    {
        void Save(Ticket ticket);
        Ticket Get(string id);
    }
}
