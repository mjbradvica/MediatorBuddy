// <copyright file="AddWidgetResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Common.Features.AddWidget
{
    /// <summary>
    /// Sample add widget response.
    /// </summary>
    public class AddWidgetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddWidgetResponse"/> class.
        /// </summary>
        /// <param name="widget">The <see cref="Widget"/> for the response.</param>
        public AddWidgetResponse(Widget widget)
        {
            Widget = widget;
        }

        /// <summary>
        /// Gets the widget response.
        /// </summary>
        public Widget Widget { get; }
    }
}
