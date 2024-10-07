using EncoreTIX.Server.Services.AttractionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncoreTIX.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionService _attractionService;
        public AttractionController(IAttractionService attractionService) => _attractionService = attractionService;

        [HttpGet]
        public async Task<IActionResult> ListAttractions([FromQuery] string? keyword = null)
        {
            var response = await _attractionService.List(keyword);
            return Ok(response);
        }

        [HttpGet("{attractionId}")]
        public async Task<IActionResult> ViewAttraction([FromRoute] string attractionId)
        {
            var response = await _attractionService.Details(attractionId);
            return Ok(response);
        }
    }
}
