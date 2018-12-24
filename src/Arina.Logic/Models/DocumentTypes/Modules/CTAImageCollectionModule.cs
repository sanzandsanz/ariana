namespace Ariana.Logic.Models
{
 
    using Ariana.Umbraco.CMS.Models;
    using System.Collections.Generic;

    public class CTAImageCollectionModule : NestedComponent
    {
        public virtual IEnumerable<CTAImageText> CTACollection { get; set; }
    }
}
