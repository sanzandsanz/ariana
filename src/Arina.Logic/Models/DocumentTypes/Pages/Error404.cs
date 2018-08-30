using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Umbraco.CMS.Models;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public class Error404 : Page, IModules
    {
        public IEnumerable<IPublishedContent> Modules { get; set; }
    }
}
