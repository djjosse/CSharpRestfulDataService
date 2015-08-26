using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Temperature class
    /// </summary>
    public class Temperature
    {
        #region Public Properties

        /// <summary>
        /// Temperature 
        /// </summary>
        public double AverageTemperature { get; set; }

        /// <summary>
        /// Maximum Temperature
        /// </summary>
        public double MaxTemperature { get; set; }

        /// <summary>
        /// Minimum Temperature
        /// </summary>
        public double MinTemperature { get; set; }

        /// <summary>
        /// Temperature Units
        /// </summary>
        public string TemperatureUnit { get; set; }

        #endregion Public Properties
    }
}
