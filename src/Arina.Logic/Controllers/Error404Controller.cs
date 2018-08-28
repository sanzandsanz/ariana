using System.Web.Mvc;
using Ariana.Logic.Models;
using Umbraco.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;


namespace Arina.Controllers
{
    public class Error404Controller : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            Error404 page = model.As<Error404>();
            return this.View("Error404", page);
        }
    }
}
