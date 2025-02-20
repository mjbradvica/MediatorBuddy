// <copyright file="AcceptedAtActionResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Accepted at action responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="string"/> action name, <see cref="string"/> controller name, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedAtActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtActionResponse<TResponse>(Func<TResponse, (string? ActionName, string? ControllerName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues) = resultFunc.Invoke(response);

                return new AcceptedAtActionResult(actionName, controllerName, routeValues, response);
            };
        }

        /// <summary>
        /// Yields a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="RouteValueDictionary"/> route values, and <see cref="object"/> value.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedAtActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtActionResponse<TResponse>(Func<TResponse, (string? ActionName, string? ControllerName, RouteValueDictionary? RouteValues, object? Value)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, value) = resultFunc.Invoke(response);

                return new AcceptedAtActionResult(actionName, controllerName, routeValues, value);
            };
        }
    }
}
