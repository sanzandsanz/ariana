using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    using Ariana.Umbraco.CMS.Models;
    using Ariana.Umbraco.CMS.Models.MediaTypes;
    using System.Collections.Generic;
    using System.Linq;

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

        public virtual IPublishedContent PrimaryNavigation { get; set; }

        public virtual string Brand { get; set; }

        public virtual Image BackgroundImage { get; set; }

        public virtual string SiteTitle { get; set; }
    }
}
