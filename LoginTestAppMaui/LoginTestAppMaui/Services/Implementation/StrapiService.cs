using System.Text.Json;
using LoginTestAppMaui.Models;
using LoginTestAppMaui.Services.Abstract;

namespace LoginTestAppMaui.Services.Implementation;

public class StrapiService : IStrapiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    public StrapiService()
    {
        _httpClient = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<List<Article>> GetArticlesAsync()
    {
        var articles = new List<Article>();
        var uri = new Uri("https://energized-wonder-181d201c9b.strapiapp.com/api/articles");

        try
        {
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(content);
                var root = jsonDoc.RootElement.GetProperty("data");
                articles = JsonSerializer.Deserialize<List<Article>>(root.GetRawText(), _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }

        return articles.ToList();
    }
}