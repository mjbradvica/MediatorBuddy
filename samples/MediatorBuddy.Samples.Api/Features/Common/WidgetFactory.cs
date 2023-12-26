// <copyright file="WidgetFactory.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.Samples.Api.Features.AddWidget;
using MediatorBuddy.Samples.Api.Features.GetAll;
using MediatorBuddy.Samples.Api.Features.GetById;
using MediatorBuddy.Samples.Api.Features.UpdateWidget;
using MediatorBuddy.Samples.Api.FluentValidationExample;

namespace MediatorBuddy.Samples.Api.Features.Common
{
    /// <summary>
    /// Sample widget factory.
    /// </summary>
    public static class WidgetFactory
    {
        /// <summary>
        /// Creates a new <see cref="Widget"/> from a request.
        /// </summary>
        /// <param name="request">A <see cref="AddWidgetRequest"/>.</param>
        /// <returns>A new <see cref="Widget"/>.</returns>
        public static Widget? FromRequest(AddWidgetRequest request)
        {
            if (request.Name == string.Empty)
            {
                return null;
            }

            return new Widget(Guid.NewGuid(), request.Name);
        }

        /// <summary>
        /// Creates a <see cref="AddWidgetResponse"/>.
        /// </summary>
        /// <param name="widget">The <see cref="Widget"/> created.</param>
        /// <returns>A new <see cref="AddWidgetResponse"/>.</returns>
        public static AddWidgetResponse AddResponse(Widget widget)
        {
            return new AddWidgetResponse(widget);
        }

        /// <summary>
        /// Creates a <see cref="GetWidgetByIdResponse"/>.
        /// </summary>
        /// <param name="widget">The <see cref="Widget"/> for the response.</param>
        /// <returns>A new <see cref="GetWidgetByIdResponse"/>.</returns>
        public static GetWidgetByIdResponse GetByIdResponse(Widget widget)
        {
            return new GetWidgetByIdResponse(widget);
        }

        /// <summary>
        /// Creates a <see cref="GetAllWidgetsResponse"/>.
        /// </summary>
        /// <param name="widgets">A <see cref="IEnumerable{T}"/> of <see cref="Widget"/>.</param>
        /// <returns>A new <see cref="GetAllWidgetsResponse"/>.</returns>
        public static GetAllWidgetsResponse GetAllResponse(IEnumerable<Widget> widgets)
        {
            return new GetAllWidgetsResponse(widgets);
        }

        /// <summary>
        /// Creates a <see cref="UpdateWidgetResponse"/>.
        /// </summary>
        /// <param name="widget">A <see cref="Widget"/>.</param>
        /// <returns>A new <see cref="UpdateWidgetResponse"/>.</returns>
        public static UpdateWidgetResponse UpdateResponse(Widget widget)
        {
            return new UpdateWidgetResponse(widget);
        }

        /// <summary>
        /// Creates a <see cref="FluentGetByIdResponse"/>.
        /// </summary>
        /// <param name="widget">A <see cref="Widget"/>.</param>
        /// <returns>A new <see cref="FluentGetByIdResponse"/>.</returns>
        public static FluentGetByIdResponse FluentResponse(Widget widget)
        {
            return new FluentGetByIdResponse(widget);
        }
    }
}
