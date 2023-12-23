// <copyright file="ResponseOptions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// A collection of functions that provide basic responses for a given status code.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="RedirectToPageResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, and <see cref="object"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPageResponse<TResponse>(Func<TResponse, (string PageName, string PageHandler, object RouteValues)> resultFunc)
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
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> page name, <see cref="string"/> page handler, and <see cref="object"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToPageResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToPageResponse<TResponse>(Func<TResponse, (string PageName, string PageHandler, object RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (pageName, pageHandler, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToPageResult(pageName, pageHandler, routeValues, false, false, fragment);
            };
        }
    }
}
