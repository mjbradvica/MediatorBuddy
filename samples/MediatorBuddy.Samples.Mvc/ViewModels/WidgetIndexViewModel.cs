// <copyright file="WidgetIndexViewModel.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Mvc.Features.Common;

namespace MediatorBuddy.Samples.Mvc.ViewModels
{
    /// <summary>
    /// Sample view model.
    /// </summary>
    public class WidgetIndexViewModel
    {
        /// <summary>
        /// Gets or sets the widgets.
        /// </summary>
        public IEnumerable<Widget> Widgets { get; set; } = Enumerable.Empty<Widget>();
    }
}
