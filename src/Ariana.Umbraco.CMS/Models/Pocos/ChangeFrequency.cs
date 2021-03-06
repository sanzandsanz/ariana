﻿using Ariana.Umbraco.ComponentModel;

namespace Ariana.Umbraco.Models
{
    /// <summary>
    /// How frequently the page is likely to change.
    /// This value provides general information to search engines and may not correlate exactly to how often they crawl the page.
    /// </summary>
    [NuPickerEnum] // This is the require custom attribute else content helper can resolve this class or any class that use this class like home.cs
    public enum ChangeFrequency
    {
        /// <summary>
        /// The page always changes. Used to describe documents that change each time they are accessed.
        /// </summary>
        Always = 1,

        /// <summary>
        /// The page changes hourly.
        /// </summary>
        Hourly = 2,

        /// <summary>
        /// The page changes daily.
        /// </summary>
        Daily = 3,

        /// <summary>
        /// The page changes weekly.
        /// </summary>
        Weekly = 0,

        /// <summary>
        /// The page changes monthly.
        /// </summary>
        Monthly = 4,

        /// <summary>
        /// The page changes yearly.
        /// </summary>
        Yearly = 5,

        /// <summary>
        /// The page changes never. Used to describe archived URLs.
        /// </summary>
        Never = 6
    }
}
