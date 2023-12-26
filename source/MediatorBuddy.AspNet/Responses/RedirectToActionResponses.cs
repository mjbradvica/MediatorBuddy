// <copyright file="RedirectToActionResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Redirect to action responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionResponse<TResponse>(Func<TResponse, (string? ActionName, string? ControllerName, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, false, false, null);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionResponse<TResponse>(Func<TResponse, (string? ActionName, string? ControllerName, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, false, false, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPermanentResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, RouteValueDictionary RouteValues)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, true, false, null);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPermanentResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, RouteValueDictionary RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, true, false, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPermanentPreserveResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, RouteValueDictionary RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, true, true, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPreserveResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, RouteValueDictionary RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, false, true, fragment);
            };
        }
    }
}
