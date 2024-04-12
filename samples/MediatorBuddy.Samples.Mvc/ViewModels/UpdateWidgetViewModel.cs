// <copyright file="UpdateWidgetViewModel.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Mvc.ViewModels
{
    /// <summary>
    /// View model for updating a widget.
    /// </summary>
    public class UpdateWidgetViewModel
    {
        /// <summary>
        /// Gets the widget id.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the widget name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
