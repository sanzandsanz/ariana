namespace Ariana.Umbraco.CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ariana.Umbraco.Helpers;
    using Our.Umbraco.Ditto;

    [DittoLazy]
    [DittoDocTypeFactory]
    public class RobotsTxt
    {
        public virtual string Content { get; set; }
    }
}
