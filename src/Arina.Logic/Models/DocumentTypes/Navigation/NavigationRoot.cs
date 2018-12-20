using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Logic.Models;
using Ariana.Umbraco.CMS.Models;

namespace Ariana.Models.DocumentTypes.Navigation
{
    public class NavigationRoot : Component
    {
        public List<LinkMenuFolder> MenuFolders => this.Children<LinkMenuFolder>().ToList();
        public List<LinkMenuItem> MenuItems => this.Children<LinkMenuItem>().ToList();
    }
}
