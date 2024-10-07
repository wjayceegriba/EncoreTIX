using EncoreTIX.Client.Shared;
using System.Net.Http.Json;

namespace EncoreTIX.Client.Services
{
    public interface IAttractionService
    {
        event Action OnChanged;
        bool IsClicked { get; set; }
        List<AttractionListViewModel> Attractions { get; set; }
        Task List(string? keyword = null);
        Task<GenericResponse<AttractionDetailsViewModel>> Details(string attractionId);
    }
    public class AttractionService : IAttractionService
    {
        private readonly HttpClient _httpClient;
        public AttractionService(HttpClient httpClient) => _httpClient = httpClient;

        public bool IsClicked { get; set; }
        public List<AttractionListViewModel> Attractions { get; set ; }

        public event Action OnChanged;

        public async Task List(string? keyword = null)
        {
            string endpoinUrl = (keyword is null) ? "api/attraction" : $"api/attraction?keyword={keyword}";
            var result = await _httpClient.GetFromJsonAsync<GenericResponse<List<AttractionListViewModel>>>(endpoinUrl);
            if (result.Data.Count != 0) Attractions = result.Data;
            else Attractions = new List<AttractionListViewModel>();

            IsClicked = true;

            OnChanged.Invoke();
        }

        public async Task<GenericResponse<AttractionDetailsViewModel>> Details(string attractionId)
        {
            var result = await _httpClient.GetFromJsonAsync<GenericResponse<AttractionDetailsViewModel>>($"api/attraction/{attractionId}");

            return result;
        }
    }
}
