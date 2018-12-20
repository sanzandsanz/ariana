using System.Linq;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    using Ariana.Umbraco.CMS.Models;

    public class Settings : Component
    {
        public HtmlInjectorSettings HtmlInjectors
        {
            get
            {
                HtmlInjectorSettings htmlInjectors = Children<HtmlInjectorSettings>().FirstOrDefault();
                if (htmlInjectors != null)
                {
                    return htmlInjectors;
                }

                return new HtmlInjectorSettings();
            }
        }

        public virtual IPublishedContent TopNavigation { get; set; }
    }
}
