using Newtonsoft.Json;

namespace WeatherClientTool.Dto
{
    public class Forecast
    {
        /// <summary>
        /// Latitude of the city.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the city.
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Generation time in ms.
        /// </summary>
        [JsonProperty("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        /// <summary>
        /// UTC offset in seconds.
        /// </summary>
        [JsonProperty("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }

        /// <summary>
        /// Timezone for the city
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Time zone abbreviation.
        /// </summary>
        [JsonProperty("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        /// <summary>
        /// Elevation
        /// </summary>
        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        /// <summary>
        /// Detail of the current weather.
        /// </summary>
        [JsonProperty("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
