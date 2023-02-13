using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherClientTool.Service;

namespace WeatherClientTool.Test
{
    public class Bootstrap
    {
        #region public properties
        public readonly IServiceProvider ServiceProvider;
        #endregion

        #region Constructor
        public Bootstrap()
        {
            var services = new ServiceCollection();

            #region Dependecy-Injection
            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            #endregion

            ServiceProvider = services.BuildServiceProvider();
        }
        #endregion
    }
}
