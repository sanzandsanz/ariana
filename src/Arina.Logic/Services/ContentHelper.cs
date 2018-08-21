namespace Ariana.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Umbraco.Core.Models;
    using Umbraco.Web;

    public class ContentHelper : IContentHelper
    {
        private readonly UmbracoHelper umbracoHelper;
        private const int RootLevel = 1;

        public ContentHelper()
        {
            umbracoHelper = new UmbracoHelper(Umbraco.Web.UmbracoContext.Current);
        }


        public IPublishedContent GetHomeNode(IPublishedContent content)
        {
            return content.AncestorOrSelf(RootLevel);
        }


        public IEnumerable<IPublishedContent> GetChildrens(IPublishedContent content)
        {
            return content.Children.AsEnumerable();
        }

        
    }
}
