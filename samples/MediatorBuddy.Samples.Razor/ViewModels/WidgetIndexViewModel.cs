﻿// <copyright file="WidgetIndexViewModel.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;
using MediatorBuddy.Samples.Common.Features.GetAll;

namespace MediatorBuddy.Samples.Razor.ViewModels
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
        /// Gets the widgets.
        /// </summary>
        public IEnumerable<Widget> Widgets { get; private set; }

        /// <summary>
        /// Action function.
        /// </summary>
        /// <param name="response">Response object.</param>
        public void FromResponse(GetAllWidgetsResponse response)
        {
            Widgets = response.Widgets;
        }
    }
}
