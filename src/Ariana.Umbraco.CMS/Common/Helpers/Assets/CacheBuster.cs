namespace Ariana.Umbraco.Helpers
{
    using System.Web;
    using System.Web.Caching;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using System.IO;
    using System;

    public static class CacheBuster
    {
        /// <summary>
        /// The template for generating css links pointing to a physical file
        /// </summary>
        private const string CssPhysicalFileTemplate = "<link rel=\"stylesheet\" href=\"{0}\" {1}/>";

        /// <summary>
        /// The template for generating JavaScript links pointing to a physical file
        /// </summary>
        private const string JavaScriptPhysicalFileTemplate = "<script type=\"text/javascript\" src=\"{0}\" {1}></script>";

        /// <summary>
        /// The template for generating the output errors on render when files cannot be found.
        /// </summary>
        private const string ErrorCommentTemplate = "<!-- File was not found '{0}' -->";

        /// <summary>
        /// The template for generating the exception message when files are not found.
        /// </summary>
        private const string FileNotFoundTemplate = "File not found '{0}'";

        /// <summary>
        /// Renders the correct html to create a unique stylesheet link to the css representing the given file
        /// with the given media query.
        /// </summary>
        /// <param name="helper">The helper this method extends.</param>
        /// <param name="rootRelativePath">The root relative path to the file.</param>
        /// <returns>
        /// The <see cref="HtmlString"/> containing the stylesheet link.
        /// </returns>
        public static HtmlString RenderCacheBusterCss(this HtmlHelper helper, string rootRelativePath)
        {
            return RenderCacheBusterCss(helper, "all", rootRelativePath);
        }

        /// <summary>
        /// Renders the correct html to create a unique stylesheet link to the css representing the given file
        /// with the given media query.
        /// </summary>
        /// <param name="helper">The helper this method extends.</param>
        /// <param name="mediaQuery">
        /// The media query to apply to the link. For reference:
        /// <see href="https://developer.mozilla.org/en-US/docs/Web/Guide/CSS/Media_queries?redirectlocale=en-US&amp;redirectslug=CSS%2FMedia_queries"/>Media Queries<a/>
        /// </param>
        /// <param name="rootRelativePath">The root relative path to the file.</param>
        /// <returns>
        /// The <see cref="HtmlString"/> containing the stylesheet link.
        /// </returns>
        public static HtmlString RenderCacheBusterCss(this HtmlHelper helper, string mediaQuery, string rootRelativePath)
        {
            try
            {
                return new HtmlString(string.Format(CssPhysicalFileTemplate, FingerPrint(rootRelativePath), mediaQuery));
            }
            catch (FileNotFoundException ex)
            {
                return new HtmlString(string.Format(ErrorCommentTemplate, rootRelativePath));
            }
        }

        /// <summary>
        /// Renders the correct html to create a unique script to the css representing the given file.
        /// </summary>
        /// <param name="helper">The helper this method extends.</param>
        /// <param name="rootRelativePath">The root relative path to the file.</param>
        /// <returns>
        /// The <see cref="HtmlString"/> containing the stylesheet link.
        /// </returns>
        public static HtmlString RenderCacheBusterJavaScript(this HtmlHelper helper, string rootRelativePath)
        {
            return RenderCacheBusterJavaScript(helper, "inline", rootRelativePath);
        }

        /// <summary>
        /// Renders the correct html to create a unique script to the css representing the given file
        /// with the given loading behaviour.
        /// </summary>
        /// <param name="helper">The helper this method extends.</param>
        /// <param name="behaviour">The string indicating how you want it to load, inline, async or defer</param>
        /// <param name="rootRelativePath">The root relative path to the file.</param>
        /// <returns>
        /// The <see cref="HtmlString"/> containing the stylesheet link.
        /// </returns>
        public static HtmlString RenderCacheBusterJavaScript(this HtmlHelper helper, string behaviour, string rootRelativePath)
        {
            string behaviourParam = behaviour == "inline"
                                        ? string.Empty
                                        : behaviour.ToString().ToLowerInvariant();

            try
            {
                return new HtmlString(string.Format(JavaScriptPhysicalFileTemplate, FingerPrint(rootRelativePath), behaviourParam));
            }
            catch (FileNotFoundException ex)
            {
                return new HtmlString(string.Format(ErrorCommentTemplate, rootRelativePath));
            }
        }

        /// <summary>
        /// Generates a unique path to the file at the given relative path.
        /// <see href="http://normansolutions.co.uk/post/cache-busting-in-c-without-querystrings#sthash.FsfoCx9Z.dpuf"/>
        /// </summary>
        /// <param name="rootRelativePath">The root relative path to the file.</param>
        /// <returns>The <see cref="string"/></returns>
        public static string FingerPrint(string rootRelativePath)
        {

            return rootRelativePath;

            //Todo:
            if (HttpRuntime.Cache[rootRelativePath] == null)
            {
                string relative = VirtualPathUtility.ToAbsolute("~" + rootRelativePath);
                string absolute = HostingEnvironment.MapPath(relative);

                if (!File.Exists(absolute))
                {
                    throw new FileNotFoundException(string.Format(FileNotFoundTemplate, rootRelativePath), absolute);
                }

                if (absolute != null)
                {
                    DateTime date = File.GetLastWriteTime(absolute);
                    int index = relative.LastIndexOf('/');
                    string result = relative.Insert(index, "/v-" + date.Ticks);
                    HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(absolute));
                }
            }

            return HttpRuntime.Cache[rootRelativePath] as string;
        }
    }
}
