// <copyright file="FluentGetByIdResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Razor.Features.Common;

namespace MediatorBuddy.Samples.Razor.FluentValidationExample
{
    /// <summary>
    /// Sample fluent get by id response.
    /// </summary>
    public class FluentGetByIdResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentGetByIdResponse"/> class.
        /// </summary>
        /// <param name="widget">The widget for the response.</param>
        public FluentGetByIdResponse(Widget widget)
        {
            Widget = widget;
        }

        /// <summary>
        /// Gets the widget response.
        /// </summary>
        public Widget Widget { get; }
    }
}
