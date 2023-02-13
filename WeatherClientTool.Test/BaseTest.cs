using Microsoft.Extensions.DependencyInjection;
using System;

namespace WeatherClientTool.Test
{
    /// <summary>
    /// Base unit test class
    /// Initializes and disposes scope before each test case
    /// </summary>
    public class BaseTest : IDisposable
    {
        protected readonly IServiceScope _scope;

        public BaseTest(Bootstrap bootstrap)
        {
            _scope = bootstrap.ServiceProvider.CreateScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
