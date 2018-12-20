using System.Collections.Generic;
using System.Linq;
using Ariana.Umbraco.CMS.Models;
using Gibe.LinkPicker.Umbraco.Models;

namespace Ariana.Logic.Models
{
    public class LinkMenuFolder : Component
    {
        public List<LinkMenuItem> MenuItems => this.Children<LinkMenuItem>().ToList();

        public bool HasChildren => this.Children<LinkMenuItem>().Any();
    }
}
