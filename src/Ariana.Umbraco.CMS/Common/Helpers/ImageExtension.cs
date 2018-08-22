using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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


        /// <summary>
        /// Gets the ImageProcessor Url by the crop alias (from the "umbracoFile" property alias)
        /// on the <see cref="Image"/> item.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> this method extends.</param>
        /// <param name="alias">The crop alias <example>thumbnail</example>.</param>
        /// <param name="useCropDimensions">Whether to use the the crop dimensions to retrieve the url.</param>
        /// <param name="useFocalPoint">Whether to use the focal point.</param>
        /// <param name="quality">The quality of jpeg images.</param>
        /// <param name="parameters">Any additional querystring parameters we need to add or replace.</param>
        /// <returns>The <see cref="ImageProcessor.Web"/> Url. </returns>
        public static string GetCropUrl(this Image image, string alias, bool useCropDimensions = true, bool useFocalPoint = true, int quality = 85, NameValueCollection parameters = null)
        {
            string url = $"{image.Crops.Src}{image.Crops.GetCropUrl(alias, useCropDimensions, useFocalPoint) + "&quality=" + quality}";

            // Replace any parameters that we need to or add new.
            if (parameters != null)
            {
                string[] split = url.Split('?');
                url = split[0];
                NameValueCollection query = HttpUtility.ParseQueryString(split[1]);

                foreach (string key in parameters)
                {
                    query[key] = parameters[key];
                }

                url = $"{url}?{query}";
            }

            return url;
        }
    }
}
