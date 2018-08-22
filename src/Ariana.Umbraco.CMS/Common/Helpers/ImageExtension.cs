using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Umbraco.CMS.Models.MediaTypes;

namespace Ariana.Umbraco.Helpers
{ 
    public static class ImageExtensions
    {
        /// <summary>
        /// Gets the url to the image. Use this instead of the url property.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> this method extends.</param>
        /// <returns>
        /// The <see cref="string"/> representing the url.
        /// </returns>
        public static string Url(this Image image)
        {
            return image.Crops.Src;
        }
    }
}
