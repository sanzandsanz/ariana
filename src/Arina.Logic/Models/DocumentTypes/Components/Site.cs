using Ariana.Umbraco.CMS.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public class Site : Component
    {
        /// <summary>
        /// Gets the settings node from within the current website.
        /// </summary>
        public Settings Settings
        {
            get
            {
                Settings settings = Children<Settings>().FirstOrDefault();
                if (settings != null)
                {
                    return settings;
                }
                return new Settings();
            }
        }
    }
}
