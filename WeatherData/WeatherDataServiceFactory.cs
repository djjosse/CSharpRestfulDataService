using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Weather Data Service Factory - create Weather Data Service object
    /// </summary>
    public class WeatherDataServiceFactory
    {
        #region Public Const Data Types for Factory

        /// <summary>
        /// Data Type to return
        /// </summary>
        public const string OPEN_WEATHER_MAP = "open_weather_map";

        #endregion Public Const Data Types for Factory

        #region Public Factory Methods

        /// <summary>
        /// Get Weather Data Service Method
        /// </summary>
        /// <param name="dataServiceType">Data Service type as string
        /// (possible values are defined in WeatherDataServiceFactory class)</param>
        /// <exception cref="WeatherDataServiceException">Thrown in case of wrong type provided</exception>
        /// <returns></returns>
        public IWeatherDataService getWeatherDataService(string dataServiceType)
        {
            IWeatherDataService service = null;
            switch (dataServiceType)
            {
                case OPEN_WEATHER_MAP:
                    service = WeatherDataService.Instance;
                    return service;
                default:
                    throw new WeatherDataServiceException(dataServiceType + " not recognized as service type.");
            }
        }

        #endregion Public Factory Methods
    }
}
