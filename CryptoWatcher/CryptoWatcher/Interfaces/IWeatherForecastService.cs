using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWatcher.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
    }
}
