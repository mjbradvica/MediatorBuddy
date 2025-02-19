// <copyright file="WidgetViewModel.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.GetById;

namespace MediatorBuddy.Samples.Mvc.ViewModels
{
    /// <summary>
    /// Sample widget view model.
    /// </summary>
    public class WidgetViewModel
    {
        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the widget name.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Creates a view model.
        /// </summary>
        /// <param name="response">A widget response.</param>
        /// <returns>A new <see cref="WidgetViewModel"/>.</returns>
        public static WidgetViewModel FromWidget(GetWidgetByIdResponse response)
        {
            return new WidgetViewModel
            {
                Id = response.Widget.Id,
                Name = response.Widget.Name,
            };
        }
    }
}
