// <copyright file="WidgetViewModel.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Mvc.Features.GetById;

namespace MediatorBuddy.Samples.Mvc.ViewModels
{
    /// <summary>
    /// Sample widget view model.
    /// </summary>
    public class WidgetViewModel
    {
        private WidgetViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the widget name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creates a view model.
        /// </summary>
        /// <param name="response">A widget response.</param>
        /// <returns>A new <see cref="WidgetViewModel"/>.</returns>
        public static WidgetViewModel FromWidget(GetWidgetByIdResponse response)
        {
            return new WidgetViewModel(response.Widget.Id, response.Widget.Name);
        }
    }
}
