using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shenkar.RestfulServices
{
    /// <summary>
    /// Extesion static class for restful services.
    /// </summary>
    public static class Extensions
    {
        #region Extension Methods
        
        /// <summary>
        /// Extension for XElement to get value by attribute name.
        /// </summary>
        /// <param name="parentEl">XElement to work on.</param>
        /// <param name="elementName">Attribute name.</param>
        /// <returns>Value of Attribute as a string or null in case not found.</returns>
        public static string TryGetVal(this XElement parentEl, string elementName)
        {
            string val = null;
            try
            {
                val = (string)parentEl.Attribute(elementName).Value;
            }
            catch (Exception) {
                
            }
            return val;
        }

        /// <summary>
        /// Extension for XElement to get value from attribute name.
        /// </summary>
        /// <param name="parentEl">Element to work on.</param>
        /// <returns>Value of Element as a string or null in case not found.</returns>
        public static string TryGetVal(this XElement parentEl)
        {
            string val = null;
            try
            {
                val = (string)parentEl.Value;
            }
            catch (Exception)
            {

            }
            return val;
        }

        #endregion Extension Methods
    }
}
