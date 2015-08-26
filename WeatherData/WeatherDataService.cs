using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// This class is weather data service.
    /// It is singleton
    /// It provides basic functionality for data service.
    /// </summary>
    public class WeatherDataService : IWeatherDataService
    {
        #region Public Consts and Definitions

        /// <summary>
        /// openweathe.org service uri
        /// </summary>
        public const string HOST = @"http://api.openweathermap.org/data/2.5/weather?";

        #endregion Public Consts and Definitions

        #region Public Properties

        /// <summary>
        /// Service Singleton Instance Property
        /// </summary>
        public static WeatherDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherDataService();
                }
                return instance;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Get weather data method
        /// </summary>
        /// <param name="location">Desired Location</param>
        /// <exception cref="WeatherDataServiceException">Thrown when where
        /// is an issue to get weather data or wrong location</exception>
        /// <returns>Weather data as an object</returns>
        public WeatherData GetWeatherData(Location location)
        {
            string uri = CreateRequest(location); 
            XDocument xml = null;
            try
            {
                xml = XDocument.Load(uri);
            }
            catch (XmlException e)
            {
                throw new WeatherDataServiceException("Failed to parse XML.", e);
            }
            WeatherData data = ParseXMLToWeatherData(xml);
            return data;
        }

        #endregion Public Methods

        #region Private Members

        /// <summary>
        /// Service singleton instance
        /// </summary>
        private static WeatherDataService instance;

        #endregion Private Members

        #region Private Constructor

        /// <summary>
        /// Weather Data Private Constructor
        /// </summary>
        private WeatherDataService() { }

        #endregion Private Constructor

        #region Private Member Functions

        /// <summary>
        /// Private function to create request to host.
        /// </summary>
        /// <param name="location">Desired Location</param>
        /// <exception cref="WeatherDataServiceException">Thrown when the location is invalid</exception>
        /// <returns>Created uri to get data as string</returns>
        private string CreateRequest(Location location)
        {
            string request = HOST;
            switch (location.GetLocationType())
            {
                case Location.LocationType.ID:
                    request += "id=" + location.CityId + "&mode=xml";
                    break;
                case Location.LocationType.ZIP:
                    request += "zip=" + location.Zip + "," + location.Country + "&mode=xml";
                    break;
                case Location.LocationType.CITYCOUNTRY:
                    request += "q=" + location.CityName + "," + location.Country + "&mode=xml";
                    break;
                case Location.LocationType.CITY:
                    request += "q=" + location.CityName + "&mode=xml";
                    break;
                case Location.LocationType.LONGLAT:
                    request += "lat=" + location.Latitude + "&lon=" + location.Longitude + "&mode=xml";
                    break;
                default:
                    throw new WeatherDataServiceException("Location not set correctly!");
            }
            return request;
        }

        /// <summary>
        /// Parsing Xml to Weather Data oject
        /// </summary>
        /// <param name="xml">XML as XDocument</param>
        /// <exception cref="WeatherDataServiceException">Thrown when where
        /// is an issue to get weather data </exception>
        /// <returns>Weather Data</returns>
        private WeatherData ParseXMLToWeatherData(XDocument xml)
        {
            //create new data object
            WeatherData data = new WeatherData();
            DateTime temp;
            string val;

            //get current value
            var current = xml.Element("current");
            if (current != null)
            {
                //create and fill location
                data.Location = new Location(-1);
                var id = current.Element("city").TryGetVal("id");
                if (id != null) data.Location.CityId = Convert.ToInt32(id);
                data.Location.CityName = current.Element("city").TryGetVal("name");
                var lon = (current.Element("city").Element("coord")).TryGetVal("lon");
                if (lon != null) data.Location.Longitude = Convert.ToDouble(lon);
                var lat = current.Element("city").Element("coord").TryGetVal("lat");
                if (lat != null) data.Location.Latitude = Convert.ToDouble(lat);
                data.Location.Country = current.Element("city").Element("country").TryGetVal();

                //create and fill temperature
                data.Temperature = new Temperature();
                val = current.Element("temperature").TryGetVal("value");
                if (val != null) data.Temperature.AverageTemperature = Convert.ToDouble(val);
                val = current.Element("temperature").TryGetVal("min");
                if (val != null) data.Temperature.MinTemperature = Convert.ToDouble(val);
                val = current.Element("temperature").TryGetVal("max");
                if (val != null) data.Temperature.MaxTemperature = Convert.ToDouble(val);
                data.Temperature.TemperatureUnit = current.Element("temperature").TryGetVal("unit");
                
                //get sunset and sunrise data
                try
                {
                    DateTime.TryParseExact((string)current.Element("city").Element("sun").TryGetVal("rise"),
                        WeatherData.DATE_FORMAT, null, DateTimeStyles.None, out temp);
                    data.Sunrise = temp;

                    DateTime.TryParseExact((string)current.Element("city").Element("sun").TryGetVal("set"),
                        WeatherData.DATE_FORMAT, null, DateTimeStyles.None, out temp);
                    data.Sunset = temp;
                }
                catch (ArgumentException) { }

                //get humidity data
                val = current.Element("humidity").TryGetVal("value");
                if (val != null) data.HumidityValue = Convert.ToDouble(val);
                data.HumidityUnit = (string)current.Element("humidity").TryGetVal("unit");

                //get pressure data
                val = current.Element("pressure").TryGetVal("value");
                if (val != null) data.PressureValue = Convert.ToDouble(val);
                data.PressureUnit = (string)current.Element("pressure").TryGetVal("unit");

                //create and fill wind data
                data.Wind = new Wind();
                val = current.Element("wind").Element("speed").TryGetVal("value");
                if (val != null) data.Wind.Speed = Convert.ToDouble(val);
                data.Wind.SpeedDescription = (string)current.Element("wind").Element("speed").TryGetVal("name");
                val = current.Element("wind").Element("direction").TryGetVal("value");
                if (val != null) data.Wind.Direction = Convert.ToInt32(val);
                data.Wind.DirectionCode = (string)current.Element("wind").Element("direction").TryGetVal("code");
                data.Wind.DirectionName = (string)current.Element("wind").Element("direction").TryGetVal("name");

                //get clouds data
                val = current.Element("clouds").TryGetVal("value");
                if (val != null) data.CloudsValue = Convert.ToInt32(val);
                data.CloudsDescription = (string)current.Element("clouds").TryGetVal("name");

                //get visiblity data
                val = current.Element("visibility").TryGetVal("value");
                if (val != null) data.Visibility = Convert.ToInt32(val);

                //create and fill precipitation data
                data.Precipitation = new Precipitation();
                data.Precipitation.Mode = (string)current.Element("precipitation").TryGetVal("mode");
                val = current.Element("precipitation").TryGetVal("value");
                if (val != null) data.Precipitation.Value = Convert.ToDouble(val);
                data.Precipitation.Unit = (string)current.Element("precipitation").TryGetVal("unit");

                //get weather number
                val = current.Element("weather").TryGetVal("number");
                if (val != null) data.WeatherNumber = Convert.ToInt32(val);

                //get last update time and date
                try
                {
                    DateTime.TryParseExact((string)current.Element("lastupdate").Attribute("value").Value,
                        WeatherData.DATE_FORMAT, null, DateTimeStyles.None, out temp);
                    data.LastUpdate = temp;
                }
                catch (ArgumentException) { }

                return data;
            }
            throw new WeatherDataServiceException("Failed to receive data! Please check your request!");
        }

        #endregion Private Member Functions
    }
}
