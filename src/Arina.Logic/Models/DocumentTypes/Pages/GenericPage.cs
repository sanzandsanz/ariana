using Ariana.Umbraco.CMS.Models;
using Ariana.Umbraco.CMS.Models.MediaTypes;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public class GenericPage : Page, IModules
    {
        public IEnumerable<IPublishedContent> Modules { get; set; }

        public virtual Image HeroBannerImage { get; set; }

        public virtual string HeroTitle { get; set; }

    }
}