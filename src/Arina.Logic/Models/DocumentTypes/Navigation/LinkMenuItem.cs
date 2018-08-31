using Gibe.LinkPicker.Umbraco.Models;

namespace Ariana.Logic.Models
{
    using Ariana.Umbraco.CMS.Models;

    public class LinkMenuItem : Component
    {
        public string Title { get; set; }

        public LinkPicker Link { get; set; }
    }
}
