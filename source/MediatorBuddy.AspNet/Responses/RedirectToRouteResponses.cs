// <copyright file="RedirectToRouteResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Redirect to route responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToRouteResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues) = resultFunc.Invoke(response);

                return new RedirectToRouteResult(routeName, routeValues, false, false, null);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, a <see cref="RouteValueDictionary"/> route values, and a <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToRouteResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToRouteResult(routeName, routeValues, false, false, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToRoutePermanentResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues) = resultFunc.Invoke(response);

                return new RedirectToRouteResult(routeName, routeValues, true, false, null);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToRoutePermanentResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToRouteResult(routeName, routeValues, true, false, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToRoutePermanentPreserveResponse<TResponse>(Func<TResponse, (string? PageName, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToRouteResult(routeName, routeValues, true, true, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> route name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToRouteResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToRoutePreserveResponse<TResponse>(Func<TResponse, (string? RouteName, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (routeName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToRouteResult(routeName, routeValues, false, true, fragment);
            };
        }
    }
}
