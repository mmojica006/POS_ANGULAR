using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace POS.Test
{
    public class CustomWebapplicationFactory: WebApplicationFactory<Program>
    {
        /// <summary>
        /// Simular la aplicación en tiempo de ejecución
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integrationConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
                configurationBuilder.AddConfiguration(integrationConfiguration);
            });
        }
    }
}
