 using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using System.Web;
using Ariana.Umbraco.CMS.Models;

namespace Arina.Logic.Models
{
    public class ContentModule : NestedComponent
    {
        public virtual string Title { get; set; }

        public virtual HtmlString Content { get; set; }
    }
}
