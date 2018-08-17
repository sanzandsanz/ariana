using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using System.Web;

namespace Arina.Logic.Models
{
    public class ContentModule 
    {
        public virtual string Title { get; set; }

        public virtual HtmlString Content { get; set; }
    }
}
