﻿using System;
using Parking.Application.Service;
using Parking.ValueObject;
using SqlServerRepository;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main()
        {
            var service = new ParkApplicationService(new ParkingBoyRepository(), new TicketRepository());
            var ticketId = service.Park(new Car("12345")).Id;
            var ticket = service.FindTicket(ticketId);
            Console.WriteLine($"{ticket.CarId}");

            var ticket2 = service.Park(new Car("12346"));
            var car = service.Take(ticket2);
            Console.WriteLine(car);
        }
    }
}