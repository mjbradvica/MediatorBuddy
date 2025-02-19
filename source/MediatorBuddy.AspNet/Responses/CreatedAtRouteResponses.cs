// <copyright file="CreatedAtRouteResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// CreatedAtRoute responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedAtRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedAtRouteResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues) = resultFunc.Invoke(response);

                return new CreatedAtRouteResult(routeName, routeValues, response);
            };
        }

        /// <summary>
        /// Yields a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, <see cref="RouteValueDictionary"/> route values, and <see cref="object"/> value.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedAtRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedAtRouteResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues, object? Value)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues, value) = resultFunc.Invoke(response);

                return new CreatedAtRouteResult(routeName, routeValues, value);
            };
        }
    }
}
