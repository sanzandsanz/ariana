using System.Web.Mvc;
using System.Web.Routing;

namespace Ariana.Umbraco.CMS.Events
{
    internal static class RouteBuilder
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Requires RAMMFAR to be enabled for the application.
            routes.MapRoute(
                "RobotsTxtRAMMFAR",
                "robots.txt",
                new { controller = "RobotsTxt", action = "Index" }
            );

            // Non RAMMFAR version.
            routes.MapRoute(
                "RobotsTxt",
                "robots-txt",
                new { controller = "RobotsTxt", action = "Index" }
            );


            // Sitemap
            routes.MapRoute("SiteMap", "sitemap.xml", new
            {
                controller = "SiteMap", action = "Index"
            });
        }
    }
}
