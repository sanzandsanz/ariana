using Ariana.Umbraco.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Our.Umbraco.Ditto;

namespace Ariana.Umbraco.CMS.Models
{
    [DittoLazy]
    [UmbracoPicker]
    public class Page
    {
        /// <inheritdoc/>
        public virtual int Id { get; set; }

        /// <inheritdoc/>
        public virtual string DocumentTypeAlias { get; set; }

        /// <inheritdoc/>
        public IEnumerable<T> Ancestors<T>(int maxLevel = int.MaxValue)
        {
            return ContentHelper.Instance.GetAncestors<T>(this.Id, maxLevel);
        }

        public IEnumerable<T> Children<T>()
        {
            return ContentHelper.Instance.GetChildren<T>(this.Id);
        }
    }
}
