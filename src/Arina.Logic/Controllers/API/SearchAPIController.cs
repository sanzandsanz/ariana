using System.Linq;
using Ariana.Logic.Models;
using Ariana.Umbraco.Helpers;
using Umbraco.Core.Models;

namespace Arina.Controllers.API
{
    using System.Collections.Generic;
    using System.Web.Http;

    public class SearchAPIController : ApiController
    {
        [HttpGet]
        [Route("api/v1/search/{searchTerm}")]
        public List<string> Search(
            string searchTerm,
            [FromUri] int pageSize = 10,
            [FromUri] int page = 1)
        {
            Home home = ContentHelper.Instance.GetHome<Home>();
            List<IPublishedContent> children = home.Modules.ToList();
            return children.Select(i => i.Name).ToList();
        }
    }
}
