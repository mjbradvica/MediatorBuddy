// <copyright file="AddWidgetViewModel.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace MediatorBuddy.Samples.Razor.ViewModels
{
    /// <summary>
    /// Sample add widget view model.
    /// </summary>
    public class AddWidgetViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
    }
}
