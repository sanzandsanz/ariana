using Ariana.Umbraco.CMS.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public class Home : Page
    {
        public IEnumerable<IPublishedContent> Modules { get; set; }
    }
}