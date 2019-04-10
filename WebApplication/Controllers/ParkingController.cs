using Microsoft.AspNetCore.Mvc;
using Parking.Application.Service;
using Parking.Domain.Tickets;
using Parking.ValueObject;
using WebApplication.Controllers.ViewObject;

namespace WebApplication.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ParkApplicationService _parkApplicationService;

        public ValuesController(ParkApplicationService parkApplicationService)
        {
            _parkApplicationService = parkApplicationService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(CreateParkingRequest request)
        {
            var ticket = _parkApplicationService.Park(new Car(request.CarId));
            var response = new CreateParkingResponse
                { CarId = ticket.CarId, LotId = ticket.LotId, SpotId = ticket.SpotId, TicketId = ticket.Id };
            return CreatedAtRoute("api/parking", new {id = ticket.Id}, response);
        }

        [HttpDelete]
        [Route("{id}")]
        public DeleteParkingResponse Delete(string id, DeleteParkingRequest request)
        {
            var car = _parkApplicationService.Take(new Ticket(id, request.CarId, request.SpotId, request.LotId));
            return new DeleteParkingResponse { CarId = car.Id };
        }
    }
}