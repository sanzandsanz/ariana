using System.ComponentModel;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;

    
namespace Ariana.Umbraco.CMS.Models.MediaTypes
{
    public class Image
    {
        public virtual string FileName { get; set; }

        
        /// <summary>
        /// Gets or sets the crops.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [UmbracoProperty("umbracoFile")]
        public virtual ImageCropDataSet Crops { get; set; }
    }
}
