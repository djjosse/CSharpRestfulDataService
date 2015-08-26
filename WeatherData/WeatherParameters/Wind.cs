using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Wind properties
    /// </summary>
    public class Wind
    {
        #region Public Properties

        /// <summary>
        /// Wind speed
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Wind speed description
        /// </summary>
        public string SpeedDescription { get; set; }

        /// <summary>
        /// Wind direction
        /// </summary>
        public double Direction { get; set; }

        /// <summary>
        /// Wind Direction Code
        /// </summary>
        public string DirectionCode { get; set; }

        /// <summary>
        /// Wind Direction Name
        /// </summary>
        public string DirectionName { get; set; }

        #endregion Public Properties
    }
}
