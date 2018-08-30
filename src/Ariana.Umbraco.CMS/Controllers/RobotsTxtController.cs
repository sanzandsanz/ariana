using Umbraco.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;
using System.Web.Mvc;
using Ariana.Umbraco.Helpers;
using Umbraco.Core.Models;
using System;
using Ariana.Umbraco.CMS.Models;
using Umbraco.Web;
using System.Linq;

namespace Ariana.Umbraco.CMS.Controllers
{
    public class RobotsTxtController : Controller
    {
        /// <summary>
        /// Represents the result of the default action method for the given path.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/> representing the result of the action.
        /// </returns>
        /// <exception cref="NullReferenceException">
        /// Returned if no home page is found.
        /// </exception>
        //[UmbracoOutputCache]
        public ActionResult Index()
        {
            int homeId = ContentHelper.Instance.GetHomeId();
            IPublishedContent home = ContentHelper.Instance.UmbracoHelper.TypedContent(homeId);
            if (home == null)
            {
                throw new NullReferenceException("Home page not found in content tree.");
            }
            IPublishedContent site = home.Parent;

            if (site == null)
            {
                throw new NullReferenceException("site node not found in content tree.");
            }

            RobotsTxt model = null;
            IPublishedContent robotsTxt = site.Descendants("robotsTxt").FirstOrDefault();
            if (robotsTxt != null)
            {
                model = robotsTxt.As<RobotsTxt>();
            }
            else
            {
                model = new RobotsTxt();
            }

            return this.View("RobotsTxt", model);
        }
    }
}
