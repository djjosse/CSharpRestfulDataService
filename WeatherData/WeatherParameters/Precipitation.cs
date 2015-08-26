using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Weather precipitation class
    /// </summary>
    public class Precipitation
    {
        #region Public Properties

        /// <summary>
        /// Precpitation Value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Precipitation Mode
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Precipitation units
        /// </summary>
        public string Unit { get; set; }

        #endregion Public Properties
    }
}
