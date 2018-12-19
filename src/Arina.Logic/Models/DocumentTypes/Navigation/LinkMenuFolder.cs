using System.Collections.Generic;
using System.Linq;
using Ariana.Umbraco.CMS.Models;

namespace Ariana.Logic.Models
{
    public class LinkMenuFolder : Component
    {
        public List<LinkMenuItem> MenuItems => this.Children<LinkMenuItem>().ToList();
    }
}
