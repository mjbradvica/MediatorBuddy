// <copyright file="WidgetViewModel.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Razor.ViewModels
{
    /// <summary>
    /// Sample widget view model.
    /// </summary>
    public class WidgetViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
