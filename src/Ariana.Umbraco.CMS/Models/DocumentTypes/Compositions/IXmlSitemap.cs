using Ariana.Umbraco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariana.Umbraco.CMS.Models
{
    public interface IXmlSitemap
    {
        /// <summary>
        /// Gets or sets a value indicating whether the page should be excluded from xml sitemap.
        /// </summary>
        bool ExcludeFromXmlSitemap { get; set; }

        /// <summary>
        /// Gets or sets the frequently the page is likely to change.
        /// This value provides general information to search engines and may not correlate exactly to how often they crawl the page.
        /// </summary>
        ChangeFrequency ChangeFrequency { get; set; }

        /// <summary>
        /// Gets or sets the priority of this URL relative to other URLs on your site.
        /// Valid values range from 0.0 to 1.0. This value does not affect how your pages are compared to pages
        /// on other sites—it only lets the search engines know which pages you deem most important for the crawlers.
        /// </summary>
        decimal Priority { get; set; }
    }
}
