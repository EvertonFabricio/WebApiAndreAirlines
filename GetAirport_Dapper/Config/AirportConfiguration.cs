using System.IO;
using Microsoft.Extensions.Configuration;

namespace GetAirport_Dapper.Config
{
    public class AirportConfiguration
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static string Get()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
            string _conection = Configuration["ConnectionStrings:DefaultConnection"];
            return _conection;
        }
    }
}
