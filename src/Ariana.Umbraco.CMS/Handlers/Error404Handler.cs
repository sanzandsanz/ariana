using System.Linq;
using Ariana.Umbraco.Helpers;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web.Routing;

namespace Ariana.Umbraco.CMS.Handlers
{
    // Should be name as Error404Finder
    public class Error404Handler : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            if (!contentRequest.Is404)
            {
                return contentRequest.PublishedContent != null;
            }

            contentRequest.SetResponseStatus(404, "404 Page Not Found");
            IPublishedContent error404 = null;

            // Set the Error404 error published page
            int homeId = ContentHelper.Instance.GetHomeId();
            if (homeId > 0)
            {
               IPublishedContent homeContent = ContentHelper.Instance.UmbracoHelper.TypedContent(homeId);
               error404 = homeContent.Children.FirstOrDefault(p => p.DocumentTypeAlias.InvariantEquals("Error404"));
               contentRequest.PublishedContent = error404;
            }

            return contentRequest.PublishedContent != null;
        }
    }
}
