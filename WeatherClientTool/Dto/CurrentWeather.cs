using Newtonsoft.Json;

namespace WeatherClientTool.Dto
{
    /// <summary>
    /// Details of the current weather
    /// </summary>
    public class CurrentWeather
    {
        /// <summary>
        /// Current temperature of the city
        /// </summary>
        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        /// <summary>
        /// Current wind speed in the city
        /// </summary>
        [JsonProperty("windspeed")]
        public double Windspeed { get; set; }

        /// <summary>
        /// Current wind direction in the city
        /// </summary>
        [JsonProperty("winddirection")]
        public double Winddirection { get; set; }

        /// <summary>
        /// Weather code for the city
        /// </summary>
        [JsonProperty("weathercode")]
        public int Weathercode { get; set; }

        /// <summary>
        /// Current time in the city.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
