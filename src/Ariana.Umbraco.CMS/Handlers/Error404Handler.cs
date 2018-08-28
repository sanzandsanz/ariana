using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Umbraco.CMS.Models;
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

            //ISiteService siteService = new SiteService();
            //IError404Service errorService = new Error404Service(siteService);

            contentRequest.SetResponseStatus(404, "404 Page Not Found");

            IPublishedContent error404 = null;
            // Set the Error404 error published page
            int homeId = ContentHelper.Instance.GetHomeId();
            if (homeId > 0)
            {
                //IPublishedContent home = contentRequest.RoutingContext.UmbracoContext.ContentCache.GetById(homeId);
                Page home = ContentHelper.Instance.GetHome<Page>();

                var error4 = home.Children<Page>(); //.FirstOrDefault(p => p.DocumentTypeAlias.InvariantEquals("Error404"));
                var error40 = error4.FirstOrDefault(p => p.DocumentTypeAlias.InvariantEquals("Error404"));


                //IPublishedContent error4 = home.Children<IPublishedContent>().FirstOrDefault(p => p.DocumentTypeAlias.InvariantEquals("Error404"));



            }
            

            

            //Site site = ContentHelper.Instance.GetSite<Site>();
            //var head = site.Settings.HtmlInjectors.Head;

            //contentRequest.PublishedContent = errorService.GetError404();

            return contentRequest.PublishedContent != null;
        }
    }
}
