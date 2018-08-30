using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Umbraco.CMS.Models;

namespace Ariana.Logic.Models
{
    public class HtmlInjectorSettings : Component
    {
        public string Head { get; set; }
        public string BodyStart { get; set; }
        public string BodyEnd { get; set; }
    }
}
