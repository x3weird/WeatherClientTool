

namespace WeatherClientTool.Dto
{
    /// <summary>
    /// details of the city location data <see cref="CityLocationData">
    /// </summary>
    public class CityLocationData
    {
        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Latitude detail of the city.
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// Longitude detail of the city.
        /// </summary>
        public string Longitude { get; set; }
    }
}
