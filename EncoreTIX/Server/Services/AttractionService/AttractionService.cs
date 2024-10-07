using EncoreTIX.Client.Pages;
using EncoreTIX.Server.Services.EventService;

namespace EncoreTIX.Server.Services.AttractionService
{
    public interface IAttractionService
    {
        Task<GenericResponse<List<AttractionListViewModel>?>> List(string? keyword);
        Task<GenericResponse<AttractionDetailsViewModel?>> Details(string? attractionId);
    }
    public class AttractionService : IAttractionService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpHelper _httpHelper;
        private readonly IMapper _mapper;

        private readonly IEventService _eventService;
        public AttractionService(IConfiguration configuration, IHttpHelper httpHelper, IMapper mapper, IEventService eventService)
        {
            _configuration = configuration;
            _httpHelper = httpHelper;
            _mapper = mapper;

            _eventService = eventService;
        }

        public async Task<GenericResponse<AttractionDetailsViewModel?>> Details(string? attractionId)
        {
            var response = await _httpHelper.GetAsync($"{_configuration["DiscoveryAPI:Endpoints:Attractions"]}/{attractionId}");

            if (response == null)
                return new GenericResponse<AttractionDetailsViewModel?>(null, "Error encountered while calling Discovery API.", StatusCodes.Status400BadRequest);

            var jsonObject = (JObject)response;
            if (response.ToString().Contains("errors"))
                return new GenericResponse<AttractionDetailsViewModel?>(null, jsonObject["errors"][0]["detail"].ToString(), StatusCodes.Status400BadRequest);

            var attraction = JsonConvert.DeserializeObject<AttractionDetailsViewModel>(JsonConvert.SerializeObject(response));
            attraction.ImageUrl = (attraction.Images.Count == 0) ? null : attraction.Images[0].Url.ToString();

            var events = await _eventService.List(attractionId);
            if (events.Data != null || events.Data.Count != 0)
                attraction.Events = events.Data;

            return new GenericResponse<AttractionDetailsViewModel?>(attraction, "Attraction details retrieved successfully.", StatusCodes.Status200OK);
        }

        public async Task<GenericResponse<List<AttractionListViewModel>?>> List(string? keyword)
        {
            var response = await _httpHelper.GetAsync($"{_configuration["DiscoveryAPI:Endpoints:Attractions"]}", keyword);
            if (!response.ToString().Contains("_embedded"))
                return new GenericResponse<List<AttractionListViewModel>?>(new List<AttractionListViewModel>(), "No results found.", StatusCodes.Status200OK);

            var jsonObject = (JObject)response;
            var fetchedData = (jsonObject["_embedded"]["attractions"] as JArray).ToObject<List<Attraction>>();
            var attractions = _mapper.Map<List<AttractionListViewModel>>(fetchedData);
            foreach (var a in attractions)
            {
                var attraction = fetchedData.Where(x => x.Id == a.Id).FirstOrDefault();
                if (attraction == null) continue;

                a.ImageUrl = attraction.Images[0].Url;
            }

            return new GenericResponse<List<AttractionListViewModel>?>(attractions, "Attractions retrieved successfully.", StatusCodes.Status200OK);
        }
    }
}
