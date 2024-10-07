using EncoreTIX.Server.Services.EventService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncoreTIX.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService) => _eventService = eventService;

        [HttpGet]
        public async Task<IActionResult> ListUpcommingEvents([FromQuery] string attractionId)
        {
            var response = await _eventService.List(attractionId);
            return Ok(response);
        }
    }
}
