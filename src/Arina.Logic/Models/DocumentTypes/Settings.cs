﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ariana.Umbraco.CMS.Models;

namespace Ariana.Logic.Models
{
    public class Settings : Component
    {
        public HtmlInjectorSettings HtmlInjectors
        {
            get
            {
                HtmlInjectorSettings htmlInjectors = Children<HtmlInjectorSettings>().FirstOrDefault();
                if (htmlInjectors != null)
                {
                    return htmlInjectors;
                }

                return new HtmlInjectorSettings();
            }
        }


        public NavigationSettings NavSettings
        {
            get
            {
                NavigationSettings navSettings = Children<NavigationSettings>().FirstOrDefault();
                if (navSettings != null)
                {
                    return navSettings;
                }

                return new NavigationSettings();
            }
        }
    }
}
