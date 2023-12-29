// <copyright file="GetAllWidgetsResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Mvc.Features.Common;

namespace MediatorBuddy.Samples.Mvc.Features.GetAll
{
    /// <summary>
    /// Sample get all widgets response.
    /// </summary>
    public class GetAllWidgetsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWidgetsResponse"/> class.
        /// </summary>
        /// <param name="widgets">A <see cref="IEnumerable{T}"/> of <see cref="Widget"/>.</param>
        public GetAllWidgetsResponse(IEnumerable<Widget> widgets)
        {
            Widgets = widgets;
        }

        /// <summary>
        /// Gets the widgets.
        /// </summary>
        public IEnumerable<Widget> Widgets { get; }
    }
}
