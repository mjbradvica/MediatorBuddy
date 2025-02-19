// <copyright file="RazorViewData.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// View and temp data for response callbacks.
    /// </summary>
    public class RazorViewData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RazorViewData"/> class.
        /// </summary>
        /// <param name="tempData">An instance of the <see cref="ITempDataDictionary"/> interface.</param>
        /// <param name="viewData">The <see cref="ViewDataDictionary"/> instance.</param>
        public RazorViewData(ITempDataDictionary tempData, ViewDataDictionary viewData)
        {
            TempData = tempData;
            ViewData = viewData;
        }

        /// <summary>
        /// Gets or sets the temp data.
        /// </summary>
        public ITempDataDictionary TempData { get; set; }

        /// <summary>
        /// Gets or sets the view data.
        /// </summary>
        public ViewDataDictionary ViewData { get; set; }

        /// <summary>
        /// Initializes the razor view data wrapper.
        /// </summary>
        /// <param name="tempData">An instance of the <see cref="ITempDataDictionary"/> interface.</param>
        /// <param name="viewData">The <see cref="ViewDataDictionary"/> instance.</param>
        /// <returns>A new <see cref="RazorViewData"/> instance.</returns>
        public static RazorViewData Initialize(ITempDataDictionary tempData, ViewDataDictionary viewData)
        {
            return new RazorViewData(tempData, viewData);
        }
    }
}
