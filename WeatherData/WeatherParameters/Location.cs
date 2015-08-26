using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// World location as class
    /// </summary>
    public class Location
    {
        #region Public Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cityName">City name string</param>
        public Location(string cityName)
        {
            CityName = cityName;
            CityId = -1;
            Longitude= -1000;
            Latitude = -1000;
            Zip = -1;
            Country = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cityName">City name string</param>
        /// <param name="countryName">Country name string</param>
        public Location(string cityName, string countryName)
        {
            CityName = cityName;
            Country = countryName;
            CityId = -1;
            Longitude = -1000;
            Latitude = -1000;
            Zip = -1;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zip">ZIP code</param>
        /// <param name="countryName">Country name string</param>
        public Location(int zip, string countryName)
        {
            Zip = zip;
            Country = countryName;
            CityId = -1;
            Longitude = -1000;
            Latitude = -1000;
            CityName = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cityId">City ID, can be found on opernweather.org</param>
        public Location(int cityId)
        {
            CityId = cityId;
            Longitude = -1000;
            Latitude = -1000;
            CityName = null;
            Zip = -1;
            Country = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="longitude">Location longitude in range of -180 to 180 degrees</param>
        /// <param name="latitude">Location latitude in range of -180 to 180 degrees</param>
        public Location(double longitude, double latitude)
        {
            if ((longitude > 180) || (longitude < -180) || (latitude > 180) || (latitude < -180))
                throw new WeatherDataServiceException("Longitude or latitude is out of range. long:" 
                                                + longitude.ToString() + " lat: " + latitude.ToString(),
                        new ArgumentOutOfRangeException("Longitude is out of range: " + longitude.ToString()));
            Longitude = longitude;
            Latitude = latitude;
            CityId = -1;
            CityName = null;
            Zip = -1;
            Country = null;
        }

        #endregion Public Constructors

        #region Enums and types

        /// <summary>
        /// Location Type Enum
        /// </summary>
        public enum LocationType 
        {
            ID, CITY, CITYCOUNTRY, LONGLAT, ZIP, UNSET
        }

        /// <summary>
        /// Defines type of location to work with.
        /// </summary>
        /// <returns>Location.LocationType enum</returns>
        public LocationType GetLocationType()
        {
            if (CityId > -1) return LocationType.ID;
            else if (!String.IsNullOrEmpty(CityName))
            {
                if (!String.IsNullOrEmpty(Country))
                return LocationType.CITYCOUNTRY;
                return LocationType.CITY;
            }
            else if ((Longitude <= 180) && (Longitude >= -180) && (Latitude >= 180) && (Latitude >= -180))
                return LocationType.LONGLAT;
            else return LocationType.UNSET;
        }

        #endregion Enums and types

        #region Location Public Properties
        
        /// <summary>
        /// City Id as at openweather.org
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Longitude in range -180 to 180 degees
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude in range -180 to 180 degees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Country Name
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public int Zip { get; set; }

        #endregion Location Public Properties
    }
}
