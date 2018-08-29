namespace Ariana.Umbraco.CMS.Controllers
{
    using System.Collections.Generic;
    using Ariana.Umbraco.Models;
    using System.Web.Mvc;
    using Ariana.Umbraco.Helpers;
    using Ariana.Umbraco.CMS.Models;

    public class SiteMapController : Controller
    {

        public ActionResult Index()
        {
            var model = new XmlSitemap();
            int homeId = ContentHelper.Instance.GetHomeId();

            Page home = ContentHelper.Instance.GetHome<Page>();
            model.Items.Add(new SitemapItem(home.UrlAbsolute(), home.UpdateDate, home.ChangeFrequency, home.Priority));

            this.AddChildren(home, model);
            return this.View("XmlSitemap", model);
        }


        private void AddChildren(Page parent, XmlSitemap viewModel, int depth = 0)
        {
            // Our recursion limit
            if (depth > 10)
            {
                return;
            }

            IEnumerable<Page> childrens = parent.Children<Page>();
            foreach (Page child in childrens)
            {
                if (!child.ExcludeFromXmlSitemap)
                {
                    SitemapItem item = new SitemapItem(child.UrlAbsolute(), child.UpdateDate, child.ChangeFrequency, child.Priority);
                    viewModel.Items.Add(item);
                    this.AddChildren(child, viewModel, depth + 1);
                }
            }
        }
    }
}
