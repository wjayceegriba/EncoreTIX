namespace EncoreTIX.Server.Services.EventService
{
    public interface IEventService
    {
        Task<GenericResponse<List<EventDetailsViewModel>?>> List(string attractionId);
    }
    public class EventService : IEventService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpHelper _httpHelper;
        private readonly IMapper _mapper;
        public EventService(IConfiguration configuration, IHttpHelper httpHelper, IMapper mapper)
        {
            _configuration = configuration;
            _httpHelper = httpHelper;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<EventDetailsViewModel>?>> List(string attractionId)
        {
            var response = await _httpHelper.GetAsync($"{_configuration["DiscoveryAPI:Endpoints:Events"]}?attractionId={attractionId}");
            if (!response.ToString().Contains("_embedded"))
                return new GenericResponse<List<EventDetailsViewModel>?>(new List<EventDetailsViewModel>(), "No upcoming events found.", StatusCodes.Status200OK);

            var jsonObject = (JObject)response;
            var fetchedData = (jsonObject["_embedded"]["events"] as JArray).ToObject<List<Event>>();
            var events = _mapper.Map<List<EventDetailsViewModel>>(fetchedData);
            foreach (var e in events)
            {
                var f = fetchedData.Where(x => x.Id == e.Id).FirstOrDefault();
                if (f != null && f._Embedded.Venues.Count != 0)
                    e.Venue = _mapper.Map<VenueDetailsViewModel>(f._Embedded.Venues[0]);
            }

            return new GenericResponse<List<EventDetailsViewModel>?>(events, "Upcoming events retrieved successfully.", StatusCodes.Status200OK);
        }
    }
}
