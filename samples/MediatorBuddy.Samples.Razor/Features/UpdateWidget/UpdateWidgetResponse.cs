// <copyright file="UpdateWidgetResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Razor.Features.Common;

namespace MediatorBuddy.Samples.Razor.Features.UpdateWidget
{
    /// <summary>
    /// Sample update widget response.
    /// </summary>
    public class UpdateWidgetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWidgetResponse"/> class.
        /// </summary>
        /// <param name="widget">A <see cref="Widget"/>.</param>
        public UpdateWidgetResponse(Widget widget)
        {
            Widget = widget;
        }

        /// <summary>
        /// Gets the new widget.
        /// </summary>
        public Widget Widget { get; }
    }
}
