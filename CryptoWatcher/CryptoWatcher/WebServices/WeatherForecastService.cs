using CryptoWatcher.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoWatcher.WebServices
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly string wheaterForecastEndpoint = "weatherforecast";

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            var response = await _httpClient.GetAsync(wheaterForecastEndpoint);
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseBody);
        }
    }
}