using System.Web.Mvc;
using Ariana.Logic.Models;
using Umbraco.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;


namespace Arina.Controllers
{
    public class SearchController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            Search page = model.As<Search>();
            return this.View("Search", page);
        }
    }
}
