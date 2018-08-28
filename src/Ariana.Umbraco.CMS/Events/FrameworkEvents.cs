using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Umbraco.CMS.Handlers;
using Umbraco.Core;
using Umbraco.Web.Routing;

namespace Ariana.Umbraco.CMS.Events
{

    public class FrameworkEvents : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentLastChanceFinderResolver.Current.SetFinder(new Error404Handler());
        }

        //protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication,
        //    ApplicationContext applicationContext)
        //{
        //}
    }
}
