using Ariana.Umbraco.CMS.Models;
using System.Collections.Generic;
using Ariana.Umbraco.CMS.Models.MediaTypes;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public class Home : Page, IModules
    {
        public IEnumerable<IPublishedContent> Modules { get; set; }
    }
}