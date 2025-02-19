// <copyright file="AcceptedAtRouteResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Accepted at route responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="string"/> route name and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedAtRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtRouteResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues) = resultFunc.Invoke(response);

                return new AcceptedAtRouteResult(routeName, routeValues, response);
            };
        }

        /// <summary>
        /// Yields a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="string"/> route name, <see cref="RouteValueDictionary"/> route values, and <see cref="object"/> value.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedAtRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtRouteResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues, object? Value)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues, value) = resultFunc.Invoke(response);

                return new AcceptedAtRouteResult(routeName, routeValues, value);
            };
        }
    }
}
