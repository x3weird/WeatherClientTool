
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using WeatherClientTool.Dto;

namespace WeatherClientTool.Service
{
    /// <summary>
    /// Service to perform weather forecast related operations <see cref="WeatherForecastService">
    /// </summary>
    public class WeatherForecastService : IWeatherForecastService
    {
        /// <summary>
        /// Prints weather information in console for passed city name.
        /// </summary>
        /// <param name="CityName">City name</param>
        /// <param name="FilePath">File path</param>
        public async Task<CurrentWeather> GetWeatherInformationAsync(string CityName, string FilePath)
        {
            List<CityLocationData> cityLocationDataList = new List<CityLocationData>();

            Forecast forecast = new();
            forecast.CurrentWeather = new CurrentWeather();
            try
            {
                
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };


                //Get data from csv file for lag and logi details.
                using (var reader = new StreamReader(FilePath))
                {
                    using (var csv = new CsvReader(reader, configuration))
                    {
                        cityLocationDataList = (csv.GetRecords<CityLocationData>()).ToList();
                    }
                }

                if (cityLocationDataList.SingleOrDefault(x => x.City.Equals(CityName, StringComparison.InvariantCultureIgnoreCase)) != null)
                {
                    var longitude = cityLocationDataList.Single(x => x.City.Equals(CityName, StringComparison.InvariantCultureIgnoreCase)).Longitude;
                    var latitude = cityLocationDataList.Single(x => x.City.Equals(CityName, StringComparison.InvariantCultureIgnoreCase)).Latitude;
                    var forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";
                    
                    //Http call to forecast url to get the data for currect weather.
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync(forecastUrl))
                        {

                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                forecast = JsonConvert.DeserializeObject<Forecast>(apiResponse);
                            }
                            else
                            {
                                Console.WriteLine("Unable to make successfull call to the weather forecast API");
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Provided city info not available.....");
                }
            }
            //If file path is incorrect or file is not present
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Incorrect file name.....");
            }
            
            
            return forecast.CurrentWeather;
        }
    }
}
