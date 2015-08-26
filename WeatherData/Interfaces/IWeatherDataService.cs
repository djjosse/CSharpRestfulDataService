using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Weather Data Service Interface
    /// </summary>
    public interface IWeatherDataService
    {
        #region Data Public Methods

        /// <summary>
        /// Method to get weather data from a service.
        /// </summary>
        /// <param name="location">Desired location.</param>
        /// <returns>Weather data as WeatherData object.</returns>
         WeatherData GetWeatherData(Location location);

        #endregion Data Public Methods
    }

}
