using Umbraco.Core;

namespace Ariana.Logic.Events
{
    using System.Web.Http;

    public class ApplicationEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }

    }
}
