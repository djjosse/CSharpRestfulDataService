using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shenkar.RestfulServices;

namespace Shenkar.RestfulServices.Test
{
    /// <summary>
    /// Weather Data Testing Class
    /// </summary>
    [TestClass]
    public class WeatherDataTests
    {
        #region Test Methods

        /// <summary>
        /// Get Weather Data Positive Test
        /// Verifies not null objectreturns form getWeatherData when valid location providen
        /// </summary>
        [TestMethod]
        public void GetWeatherDataTest_ValidDataObjectReturned_Positive()
        {
            Location location = new Location(2172797);

            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();

            IWeatherDataService service 
                = factory.getWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);

            WeatherData data = service.GetWeatherData(location);

            Assert.IsNotNull(data);
        }

        /// <summary>
        /// Get Weather Data Positive Test
        /// Verifies exception thrown when invalid location providen
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(WeatherDataServiceException), "Wrong data type data request")]
        public void GetWeatherDataTest_ExceptionThrownOnWrongWeatherDataType_Negative()
        {
            const string WRONG_DATA_TYPE = "WrongWeatherType";

            Location location = new Location(2172797);

            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();

            IWeatherDataService service
                = factory.getWeatherDataService(WRONG_DATA_TYPE);
        }

        #endregion Test Methods
    }
}
