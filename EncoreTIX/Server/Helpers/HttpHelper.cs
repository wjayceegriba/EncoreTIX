namespace EncoreTIX.Server.Helpers
{
    public interface IHttpHelper
    {
        Task<dynamic> GetAsync(string url, string? keyword = null);
    }
    public class HttpHelper: IHttpHelper
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public HttpHelper(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<dynamic> GetAsync(string url, string? keyword = null)
        {
            string endpointUrl = (keyword is null) ? $"{url}" : $"{url}?keyword={keyword}";
            endpointUrl = (endpointUrl.Contains("?")) ? $"{endpointUrl}&" : $"{endpointUrl}?";
            var response = await _httpClient.GetAsync($"{endpointUrl}apikey={_configuration["DiscoveryAPI:ApiKey"]}");
            var result = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject(result);
            return responseObject;
        }
    }
}
