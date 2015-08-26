using Shenkar.RestfulServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulServices.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Location location = new Location("Tel Aviv");
            IWeatherDataService service = WeatherDataService.Instance;
            WeatherData data = service.GetWeatherData(location);
            Console.WriteLine(data.ToString());
           

            Console.ReadKey();
        }
    }
}
