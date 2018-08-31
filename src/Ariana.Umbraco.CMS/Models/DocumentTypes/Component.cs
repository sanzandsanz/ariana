using System;
using System.Collections.Generic;
using System.Text;
using Ariana.Umbraco.Helpers;
using Our.Umbraco.Ditto;

namespace Ariana.Umbraco.CMS.Models
{
    [DittoLazy]
    [DittoDocTypeFactory]
    public class Component
    {
        public virtual int Id { get; set; }

        public virtual string DocumentTypeAlias { get; set; }

        public virtual IEnumerable<T> Children<T>()
        {
            return ContentHelper.Instance.GetChildren<T>(this.Id);
        }
    }
}
