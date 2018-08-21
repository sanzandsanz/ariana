using System.Web.Mvc;
using Ariana.Logic.Models;
using Umbraco.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;
using Ariana.Services;

namespace Arina.Controllers
{
    public class HomeController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {

            ContentHelper contentHelper = new ContentHelper();
            contentHelper.GetHomeNode(model.Content);


            Home page = model.As<Home>();
            return this.View("Home", page);
        }
    }
}
