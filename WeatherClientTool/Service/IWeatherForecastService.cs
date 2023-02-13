
using WeatherClientTool.Dto;

namespace WeatherClientTool.Service
{
    public interface IWeatherForecastService
    {
        public Task<CurrentWeather> GetWeatherInformationAsync(string CityName, string FilePath);
    }
}
