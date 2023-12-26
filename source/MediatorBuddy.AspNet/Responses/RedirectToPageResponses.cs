// <copyright file="RedirectToPageResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Redirect to page responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPageResponse<TResponse>(Func<TResponse, (string? PageName, string? PageHandler, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (pageName, pageHandler, routeValues) = resultFunc.Invoke(response);

                return new RedirectToPageResult(pageName, pageHandler, routeValues, false, false, null);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, a <see cref="RouteValueDictionary"/> route values, and a <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPageResponse<TResponse>(Func<TResponse, (string? PageName, string? PageHandler, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (pageName, pageHandler, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToPageResult(pageName, pageHandler, routeValues, false, false, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, and <see cref="RouteValueDictionary"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPagePermanentResponse<TResponse>(Func<TResponse, (string? PageName, string? PageHandler, RouteValueDictionary? RouteValues)> resultFunc)
        {
            return response =>
            {
                var (pageName, pageHandler, routeValues) = resultFunc.Invoke(response);

                return new RedirectToPageResult(pageName, pageHandler, routeValues, true, false, null);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPagePermanentResponse<TResponse>(Func<TResponse, (string? PageName, string? PageHandler, RouteValueDictionary? RouteValues, string? Fragment)> resultFunc)
        {
            return response =>
            {
                var (pageName, pageHandler, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToPageResult(pageName, pageHandler, routeValues, true, false, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPagePermanentPreserveResponse<TResponse>(Func<TResponse, (string PageName, string PageHandler, RouteValueDictionary RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (pageName, pageHandler, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToPageResult(pageName, pageHandler, routeValues, true, true, fragment);
            };
        }

        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="RouteValueDictionary"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPagePreserveResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, RouteValueDictionary RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToPageResult(actionName, controllerName, routeValues, false, true, fragment);
            };
        }
    }
}
