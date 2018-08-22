 using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using System.Web;
using Ariana.Umbraco.CMS.Models;
 using Ariana.Umbraco.CMS.Models.MediaTypes;

namespace Arina.Logic.Models
{
    public class ImageModule : NestedComponent
    {
        public virtual string Title { get; set; }

        public virtual Image Image { get; set; }
    }
}
