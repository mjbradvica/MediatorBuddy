// <copyright file="WidgetIndexViewModel.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Razor.Features.Common;

namespace MediatorBuddy.Samples.Razor.Pages.Widgets
{
    /// <summary>
    /// Sample widget index view model.
    /// </summary>
    public class WidgetIndexViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetIndexViewModel"/> class.
        /// </summary>
        public WidgetIndexViewModel()
        {
            Widgets = new List<Widget>();
        }

        /// <summary>
        /// Gets or sets the widgets.
        /// </summary>
        public IEnumerable<Widget> Widgets { get; set; }
    }
}
