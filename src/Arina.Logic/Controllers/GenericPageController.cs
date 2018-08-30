using System.Web.Mvc;
using Ariana.Logic.Models;
using Umbraco.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;


namespace Arina.Controllers
{
    // Make sure the DocumentType Name === ControllerName
    // There should be GenericPage Document Type for this page 
    public class GenericPageController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            GenericPage page = model.As<GenericPage>();
            return this.View("GenericPage", page);
        }
    }
}
