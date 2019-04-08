using System;
using MemoryCacheRepository;
using Parking.Application.Service;
using Parking.ValueObject;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ParkApplicationService(new ParkingBoyRepository(), new TicketRepositpry());
            var ticketId = service.Park(new Car("12345")).Id;
            var ticket = service.FindTicket(ticketId);
            Console.WriteLine($"{ticket.CarId}");
        }
    }
}
