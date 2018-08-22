using Ariana.Umbraco.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ariana.Umbraco.CMS.Models
{
    public class Page
    {
        /// <inheritdoc/>
        public virtual int Id { get; set; }

        /// <inheritdoc/>
        public IEnumerable<T> Ancestors<T>(int maxLevel = int.MaxValue)
        {
            return ContentHelper.Instance.GetAncestors<T>(this.Id, maxLevel);
        }
    }
}
