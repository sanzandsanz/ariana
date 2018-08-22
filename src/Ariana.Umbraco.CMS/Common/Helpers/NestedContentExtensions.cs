using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;

namespace Ariana.Umbraco.Helpers
{
    public static class NestedContentExtensions
    {
        public static MvcHtmlString NestedContent(this HtmlHelper htmlHelper, IEnumerable<IPublishedContent> modules, string siteName = null, string viewsPath = "~/Views/Partials/NestedContent/")
        {
            string html = string.Empty;
            if (modules != null && modules.Any())
            {
                foreach (IPublishedContent content in modules)
                {
                    Type type = ContentHelper.Instance.GetRegisteredType(content.DocumentTypeAlias);
                    if (type != null)
                    {
                        object viewModel = content.As(type);
                        html += HierarchicalPartial(htmlHelper, type.Name, viewModel, siteName, viewsPath);
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.IsDebuggingEnabled)
                        {
                            string errorMessage = string.Format("The model for the Document Type '{0}' does not exist, please try creating the model for this Document Type.", content.DocumentTypeAlias);
                            html += htmlHelper.Partial(viewsPath + "_Error.cshtml", errorMessage);
                        }
                    }
                }
            }
            return new MvcHtmlString(html);
        }



        /// <summary>
        /// Allows for hierarchical loading of the partial to allow overriding the module markup.
        /// </summary>
        /// <param name="htmlHelper"><see cref="HtmlHelper"/></param>
        /// <param name="typeName">The name of the Model being used, this will be an the Uppercase First variant of the docuemnt type alias.</param>
        /// <param name="viewModel">The model that was loaded for use with the view.</param>
        /// <param name="siteName">An optional siteName to load the view in a folder under the viewspath.</param>
        /// <param name="viewsPath">The view path to load the files from.</param>
        /// <returns>The string containing the HTML from the relevant loaded view.</returns>
        private static string HierarchicalPartial(HtmlHelper htmlHelper, string typeName, object viewModel, string siteName, string viewsPath)
        {
            string relativePath = string.Empty;
            string absolutePath = string.Empty;
            string html = string.Empty;

            if (!string.IsNullOrEmpty(siteName))
            {
                relativePath = viewsPath + siteName + "/_" + typeName + ".cshtml";
                absolutePath = HostingEnvironment.MapPath(relativePath);
                if (System.IO.File.Exists(absolutePath))
                {
                    html += htmlHelper.Partial(relativePath, viewModel);
                }
            }

            if (string.IsNullOrEmpty(html))
            {
                relativePath = viewsPath + "_" + typeName + ".cshtml";
                absolutePath = HostingEnvironment.MapPath(relativePath);
                if (System.IO.File.Exists(absolutePath))
                {
                    html += htmlHelper.Partial(relativePath, viewModel);
                }
                else
                {
                    if (System.Web.HttpContext.Current.IsDebuggingEnabled)
                    {
                        string errorMessage = string.Format("Unable to find the view file: '{0}'", relativePath);
                        html += htmlHelper.Partial(viewsPath + "_Error.cshtml", errorMessage);
                    }
                }
            }
            return html;
        }
    }
}
