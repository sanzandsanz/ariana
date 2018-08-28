using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Ariana.Logic.Models
{
    public interface IModules
    {
        IEnumerable<IPublishedContent> Modules { get; set; }
    }
}
