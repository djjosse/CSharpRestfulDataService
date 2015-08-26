using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// This class is Weather data exception
    /// This exception is thrown by weather data services in case of an error.
    /// </summary>
    public class WeatherDataServiceException :Exception
    {
        #region Public Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Description of exception</param>
        public WeatherDataServiceException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Description of exception.</param>
        /// <param name="innerExcepion">Wrapped inner exception.</param>
        public WeatherDataServiceException(string message, Exception innerExcepion)
            : base(message, innerExcepion) { }

        #endregion Public Constructors
    }
}
