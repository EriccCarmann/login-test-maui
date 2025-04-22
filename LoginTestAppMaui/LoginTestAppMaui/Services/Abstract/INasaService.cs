using Newtonsoft.Json.Linq;

namespace LoginTestAppMaui.Services.Abstract
{
    public interface INasaService
    {
        Task<JArray> GetAsteroids();
    }
}
