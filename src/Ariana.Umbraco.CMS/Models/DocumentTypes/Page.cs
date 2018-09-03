using Ariana.Umbraco.CMS.Models.MediaTypes;

namespace Ariana.Umbraco.CMS.Models
{
    using Ariana.Umbraco.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Our.Umbraco.Ditto;
    using Ariana.Umbraco.Models;
    using System.Web;

    [DittoLazy]
    [UmbracoPicker]
    public class Page : IXmlSitemap, IMeta
    {
        /// <inheritdoc/>
        public virtual int Id { get; set; }

        /// <inheritdoc/>
        public virtual string DocumentTypeAlias { get; set; }
     
        /// <inheritdoc/>
        public IEnumerable<T> Ancestors<T>(int maxLevel = int.MaxValue)
        {
            return ContentHelper.Instance.GetAncestors<T>(this.Id, maxLevel);
        }

        public IEnumerable<T> Children<T>()
        {
            return ContentHelper.Instance.GetChildren<T>(this.Id);
        }

        /// <inheritdoc/>
        public virtual DateTime UpdateDate { get; set; }

        public bool ExcludeFromXmlSitemap { get; set; }
        public ChangeFrequency ChangeFrequency { get; set; }
        public decimal Priority { get; set; }

        public virtual string UrlAbsolute()
        {
            string url = ContentHelper.Instance.UmbracoHelper.UrlAbsolute(this.Id);

            // Certain virtual pages such as Articulate blog pages only return a relative url.
            //if (!url.IsAbsoluteUrl())
            //{
            //    string root = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            //    url = new Uri(new Uri(root, UriKind.Absolute), url).ToString();
            //}

            string root = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            url = new Uri(new Uri(root, UriKind.Absolute), url).ToString();

            return url;
        }


        // Open Graph
        public string BrowserTitle { get; set; }
        public string BrowserDescription { get; set; }
        public string OpenGraphTitle { get; set; }
        public string OpenGraphType { get; set; }
        public Image OpenGraphImage { get; set; }

        [DittoIgnore]
        public string OpenGraphUrl => this.UrlAbsolute();
    }
}
