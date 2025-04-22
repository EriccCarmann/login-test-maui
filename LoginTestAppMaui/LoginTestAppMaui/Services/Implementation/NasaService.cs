using LoginTestAppMaui.Services.Abstract;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace LoginTestAppMaui.Services.Implementation
{
    public class NasaService : INasaService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.nasa.gov/";
        private const string AccessKey = "RfCcSuXUD9tnNGoTZCrPnJY5hu1vdzHg22qujPUj";

        public NasaService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Client-ID", AccessKey);
        }

        public async Task<JArray> GetAsteroids()
        {
            string endDate = DateTime.Now.ToString("yyyy-MM-dd");
            string startDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            var response = await _httpClient.GetAsync($"neo/rest/v1/feed?start_date={startDate}&end_date={endDate}&api_key={AccessKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            Console.Write(json);
            return (JArray)json["results"];
        }
    }
}
