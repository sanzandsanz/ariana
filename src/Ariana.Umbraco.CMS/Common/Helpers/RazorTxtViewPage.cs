namespace Ariana.Umbraco.Helpers
{
    using System.Web.Mvc;
    using System.Web.WebPages;

    /// <summary>
    /// Represents the properties and methods that are needed in order to render an TXT view.
    /// <remarks>
    /// Using this type allows us to always avoid the error where a line of space is inserted before
    /// the opening TXT declaration.
    /// </remarks>
    /// </summary>
    /// <typeparam name="T">
    /// The type of the view data model.
    /// </typeparam>
    public class RazorTxtViewPage<T> : WebViewPage<T>
    {
        /// <summary>
        /// Runs the page hierarchy for the ASP.NET Razor execution pipeline.
        /// </summary>
        public override void ExecutePageHierarchy()
        {
            this.Response.ContentType = "text/plain; charset=UTF-8";
            this.Layout = null;
            this.PushContext(new WebPageContext(), this.Response.Output);
            base.ExecutePageHierarchy();
        }

        /// <summary>
        /// Executes the server code in the current web page that is marked using Razor syntax.
        /// </summary>
        public override void Execute()
        {
        }
    }
}
