namespace Ariana.Umbraco.Models {

    using System.Collections.Generic;

    /// <summary>
    /// Represents a single sitemap item.
    /// </summary>
    public class XmlSitemap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSitemap"/> class.
        /// </summary>
        public XmlSitemap()
        {
            this.Items = new HashSet<SitemapItem>();
        }

        /// <summary>
        /// Gets the sitemap items.
        /// </summary>
        public ICollection<SitemapItem> Items { get; private set; }
    }

}
