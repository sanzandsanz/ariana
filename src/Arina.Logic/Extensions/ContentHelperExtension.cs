using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Logic.Models;
using Ariana.Umbraco.Helpers;

namespace Ariana.Extensions
{
    public static class ContentHelperExtension
    {

        public static Settings GetSiteSettings(this ContentHelper helper)
        {
            Settings settings = helper.GetSite<Site>().Children<Settings>().FirstOrDefault();
            return settings ?? null;
        }
    }
}
