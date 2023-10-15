// <copyright file="Index.cshtml.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediatorBuddy.Samples.Razor.Pages
{
    /// <summary>
    /// Page for Index View.
    /// </summary>
#pragma warning disable SA1649 // File name should match first type name
    public class IndexModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Action for http get.
        /// </summary>
        public void OnGet()
        {
        }
    }
}