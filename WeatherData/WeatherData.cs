using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Weather data represent all parameters and location.
    /// </summary>
    public class WeatherData
    {
        #region Const Definitions

        /// <summary>
        /// Date and Time format on openweather.org
        /// </summary>
        public const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss";

        #endregion Const Definitions

        #region Public Properties

        /// <summary>
        /// Prognoze Location 
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Sunrise time
        /// </summary>
        public DateTime Sunrise { get; set; }

        /// <summary>
        /// Sunset time
        /// </summary>
        public DateTime Sunset { get; set; }

        /// <summary>
        /// Temperature
        /// </summary>
        public Temperature Temperature { get; set; }

        /// <summary>
        /// Humidity value
        /// </summary>
        public double HumidityValue { get; set; }

        /// <summary>
        /// Humidity units
        /// </summary>
        public string HumidityUnit { get; set; }

        /// <summary>
        /// Pressure value
        /// </summary>
        public double PressureValue { get; set; }

        /// <summary>
        /// Pressure Unit
        /// </summary>
        public string PressureUnit { get; set; }

        /// <summary>
        /// Wind direction and speed
        /// </summary>
        public Wind Wind { get; set; }

        /// <summary>
        /// Clouds value
        /// </summary>
        public int CloudsValue { get; set; }

        /// <summary>
        /// Clouds description
        /// </summary>
        public string CloudsDescription { get; set; }

        /// <summary>
        /// Vsibility value
        /// </summary>
        public int Visibility { get; set; }

        /// <summary>
        /// Precipitation value mode and unit
        /// </summary>
        public Precipitation Precipitation { get; set; }

        /// <summary>
        /// Weather Number on openweather.org
        /// </summary>
        public int WeatherNumber { get; set; }

        /// <summary>
        /// Last update time and date
        /// </summary>
        public DateTime LastUpdate { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// To string method for debugging purposes
        /// </summary>
        /// <returns>Weather data as string</returns>
        public override string ToString()
        {
             return String.Format("Weather data for (id: {0}) {1} {2} zip: {3} ({4} {5})\n" + 
                "Sunrise: {6} Sunset: {7} \n Last Update: {8}\n" +
                "Temperture: {10} {11} {12} {13}\n" +
                "Humidity: {14} {15} Pressure: {16} {17}\n" +
                "Wind speed: {18} {19} direction: {20} {21}\n" +
                "Clouds {22} {23} Visibility {24}\n" +
                "Precipitation {25} {26} {27}\n" +
                "WeatherNumber {28}\n",
                Location.CityId, Location.CityName, Location.Country, Location.Zip, Location.Latitude, Location.Longitude,
                Sunrise, Sunset, LastUpdate,
                Temperature.AverageTemperature, Temperature.MinTemperature, Temperature.MaxTemperature, Temperature.TemperatureUnit,
                HumidityValue, HumidityUnit,
                PressureValue, PressureUnit,
                Wind.Speed, Wind.SpeedDescription, Wind.Direction, Wind.DirectionCode, Wind.DirectionName,
                CloudsValue, CloudsDescription, Visibility,
                Precipitation.Mode, Precipitation.Value, Precipitation.Unit,
                WeatherNumber);
        }

        #endregion Public Methods
    }
}
