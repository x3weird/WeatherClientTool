
using Microsoft.Extensions.DependencyInjection;
using WeatherClientTool.Dto;
using WeatherClientTool.Service;

public class Program
{
    public static  async Task Main(string[] args)
    {
        var collection = new ServiceCollection();
        collection.AddSingleton<IWeatherForecastService, WeatherForecastService>();   
        IServiceProvider serviceProvider = collection.BuildServiceProvider();

        var weatherForecastService = serviceProvider.GetService<IWeatherForecastService>();
        
        try
        {
            var cityName = args[0];

            //Get weather details
            CurrentWeather currentWeather = await weatherForecastService.GetWeatherInformationAsync(cityName, "CityData.csv");

            //Print to console weather details.
            Console.WriteLine($"City Name : {cityName}");
            Console.WriteLine($"Temperature : {currentWeather.Temperature}");
            Console.WriteLine($"Wind Speed : {currentWeather.Windspeed}");
            Console.WriteLine($"Wind Direction : {currentWeather.Winddirection}");
            Console.WriteLine($"Time : {currentWeather.Time}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Please provide city name in command line argument.");
        }

        if (serviceProvider is IDisposable)
        {
            ((IDisposable)serviceProvider).Dispose();
        }
        Console.ReadLine();
    }
}