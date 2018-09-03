using System.Collections.Generic;
using Ariana.Umbraco.CMS.Models.MediaTypes;
using Umbraco.Core.Models;

namespace Ariana.Umbraco.CMS.Models
{
    public interface IMeta
    {
        /// <summary>
        /// Gets or sets the page title that will be displayed to search engines and in
        /// the browser tab.
        /// <remarks>
        /// Identified in the back office as browserTitle.
        /// </remarks>
        /// </summary>
        string BrowserTitle { get; set; }

        /// <summary>
        /// Gets or sets the page description search engine results. Optimum 150 - 160 characters.
        /// <remarks>
        /// Identified in the back office as browserDescription.
        /// </remarks>
        /// </summary>
        string BrowserDescription { get; set; }

        /// <summary>
        /// Gets or sets the title of the document as it should appear when shared in social media, <example>Deepend</example>.
        /// </summary>
        string OpenGraphTitle { get; set; }

        /// <summary>
        /// Gets or sets the type of your document as it should appear when shared in social media, <example>website</example>.
        /// <remarks>
        /// Depending on the type you specify, other properties may also be required.
        /// <see href="http://ogp.me/#types"/> for more information.
        /// </remarks>
        /// </summary>
        string OpenGraphType { get; set; }

        /// <summary>
        /// Gets or sets the URL to the image that represents your document when shared in social media.
        /// <remarks>
        /// The Open Graph protocol expects the full qualified URL to the image. Use <see cref="M:Image.UrlAbsolute"/>
        /// to return the correct value.
        /// </remarks>
        /// </summary>
        Image OpenGraphImage { get; set; }

        /// <summary>
        /// Gets the canonical URL of your document that will be used as its permanent ID when shared in social media.
        /// </summary>
        string OpenGraphUrl { get; }
    }
}
