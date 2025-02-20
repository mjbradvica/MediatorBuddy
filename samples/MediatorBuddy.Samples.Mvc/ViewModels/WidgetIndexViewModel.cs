// <copyright file="WidgetIndexViewModel.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;

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
