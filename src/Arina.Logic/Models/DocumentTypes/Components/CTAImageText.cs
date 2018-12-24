namespace Ariana.Logic.Models
{
    using Ariana.Umbraco.CMS.Models;
    using Ariana.Umbraco.CMS.Models.MediaTypes;

    public class CTAImageText : Component
    {
        public virtual string Title { get; set; }
        public virtual Image Image { get; set; }
    }
}
