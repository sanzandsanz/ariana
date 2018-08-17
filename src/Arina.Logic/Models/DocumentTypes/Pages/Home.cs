using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public class Home
    {
        public IEnumerable<IPublishedContent> Modules { get; set; }
    }
}
