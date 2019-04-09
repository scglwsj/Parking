using Parking.Domain.Tickets;

namespace SqlServerRepository.DataObject
{
    public partial class TicketDo
    {
        public TicketDo(Ticket ticket)
        {
            Id = ticket.Id;
            LotId = ticket.LotId;
            SpotId = ticket.SpotId;
            CarId = ticket.CarId;
        }

        public TicketDo()
        {
        }

        public string Id { get; set; }
        public string LotId { get; set; }
        public string SpotId { get; set; }
        public string CarId { get; set; }

        public Ticket Entity => new Ticket(Id, CarId, SpotId, LotId);
    }
}