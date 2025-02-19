// <copyright file="CreatedAtActionResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Created at action responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, a <see cref="string"/> controller name, and a <see cref="RouteValueDictionary"/> route values.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedAtActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedAtActionResponse<TResponse>(Func<TResponse, (string? ActionName, string? ControllerName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues) = resultFunc.Invoke(response);

                return new CreatedAtActionResult(actionName, controllerName, routeValues, response);
            };
        }

        /// <summary>
        /// Yields a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, a <see cref="string"/> controller name, a <see cref="RouteValueDictionary"/> route values, and <see cref="object"/> value.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedAtActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedAtActionResponse<TResponse>(Func<TResponse, (string? ActionName, string? ControllerName, RouteValueDictionary? RouteValues, object? Value)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, value) = resultFunc.Invoke(response);

                return new CreatedAtActionResult(actionName, controllerName, routeValues, value);
            };
        }
    }
}
