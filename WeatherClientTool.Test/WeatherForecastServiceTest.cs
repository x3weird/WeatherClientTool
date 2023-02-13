using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading.Tasks;
using WeatherClientTool.Service;
using Xunit;

namespace WeatherClientTool.Test
{
    [Collection("Register Dependency")]
    public class WeatherForecastServiceTest : BaseTest
    {

        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastServiceTest(Bootstrap bootstrap) : base(bootstrap)
        {
            _weatherForecastService = bootstrap.ServiceProvider.GetService<IWeatherForecastService>();
        }

        /// <summary>
        /// Check if every thing correctly provided then it return data.
        /// </summary>
        [Fact]
        public async Task GetWeatherInformationAsync_PassCorrectCityName_Success()
        {
            //Act
            var actual = await _weatherForecastService.GetWeatherInformationAsync("Kolkata", "CityData.csv");

            //Asset
            Assert.NotNull(actual.Time);
        }

        /// <summary>
        /// Check if incorrect city name provided then it return null time.
        /// </summary>
        [Fact]
        public async Task GetWeatherInformationAsync_PassIncorrectCityName_Failure()
        {
            //Act
            var actual = await _weatherForecastService.GetWeatherInformationAsync("Kolkata123", "CityData.csv");

            //Asset
            Assert.Null(actual.Time);
        }

        /// <summary>
        /// Check if incorrect file path provided then it return null time.
        /// </summary>
        [Fact]
        public async Task GetWeatherInformationAsync_PassIncorrectFilePath_Failure()
        {
            //Act
            var actual = await _weatherForecastService.GetWeatherInformationAsync("Kolkata", "CityData1.csv");

            //Asset
            Assert.Null(actual.Time);
        }
    }
}