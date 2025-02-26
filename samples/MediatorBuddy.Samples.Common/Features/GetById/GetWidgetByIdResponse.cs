﻿// <copyright file="GetWidgetByIdResponse.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Common.Features.GetById
{
    /// <summary>
    /// Sample get widget by id response.
    /// </summary>
    public class GetWidgetByIdResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWidgetByIdResponse"/> class.
        /// </summary>
        /// <param name="widget">The <see cref="Widget"/> for the response.</param>
        public GetWidgetByIdResponse(Widget widget)
        {
            Widget = widget;
        }

        /// <summary>
        /// Gets the widget for the response.
        /// </summary>
        public Widget Widget { get; }
    }
}
