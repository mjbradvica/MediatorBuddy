// <copyright file="AcceptedAtActionResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Accepted at action responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields an empty <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield an action name, controller name, and route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedAtActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtActionResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues) = resultFunc.Invoke(response);

                return new AcceptedAtActionResult(actionName, controllerName, routeValues, response);
            };
        }

        /// <summary>
        /// Yields an empty <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield an action name, controller name, and route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedAtActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtActionResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues, object Value)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, value) = resultFunc.Invoke(response);

                return new AcceptedAtActionResult(actionName, controllerName, routeValues, value);
            };
        }
    }
}
