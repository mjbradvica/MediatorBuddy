// <copyright file="ResponseOptions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// A collection of functions that provide basic responses for a given status code.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Returns a function that will yield a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <param name="actionName">The name of the controller action.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type AcceptedAtActionResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtActionResponse<TResponse>(string actionName, string controllerName, Func<TResponse, object> routeValuesFunc)
        {
            return response => new AcceptedAtActionResult(actionName, controllerName, routeValuesFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="routeName">The name of the route where the response object may be found.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedAtRouteResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedAtRouteResponse<TResponse>(string routeName, Func<TResponse, object> routeValuesFunc)
        {
            return response => new AcceptedAtRouteResult(routeName, routeValuesFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="location">The Uri where the resource can be accessed.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResponse.</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(Uri location)
        {
            return response => new CreatedResult(location, response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="locationFunc">The Uri where the resource can be accessed.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResponse.</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(Func<TResponse, Uri> locationFunc)
        {
            return response => new CreatedResult(locationFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="location">A string that represents a Uri location of the resource.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResult.</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(string location)
        {
            return response => new CreatedResult(location, response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="locationFunc">A string that represents a Uri location of the resource.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResult.</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(Func<TResponse, string> locationFunc)
        {
            return response => new CreatedResult(locationFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="actionName">The name of the controller action.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedAtActionResult.</returns>
        public static Func<TResponse, IActionResult> CreatedAtActionResponse<TResponse>(string actionName, string controllerName, Func<TResponse, object> routeValuesFunc)
        {
            return response => new CreatedAtActionResult(actionName, controllerName, routeValuesFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <returns>A function that will return an IActionResult of type CreatedAtRouteResult.</returns>
        public static Func<TResponse, IActionResult> CreatedAtRouteResponse<TResponse>(Func<TResponse, object> routeValuesFunc)
        {
            return response => new CreatedAtRouteResult(routeValuesFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="routeName">The name of the route where the response object may be found.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <returns>A function that will return an IActionResult of type CreatedAtRouteResult.</returns>
        public static Func<TResponse, IActionResult> CreatedAtRouteResponse<TResponse>(string routeName, Func<TResponse, object> routeValuesFunc)
        {
            return response => new CreatedAtRouteResult(routeName, routeValuesFunc.Invoke(response), response);
        }

        /// <summary>
        /// Yields a <see cref="ContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="int"/> status code, <see cref="string"/> content value, and <see cref="string"/> content type.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ContentResult"/>.</returns>
        public static Func<TResponse, IActionResult> ContentResponse<TResponse>(Func<TResponse, (int StatusCode, string Content, string ContentType)> resultFunc)
        {
            return response =>
            {
                var (statusCode, content, contentType) = resultFunc.Invoke(response);

                return new ContentResult
                {
                    StatusCode = statusCode,
                    Content = content,
                    ContentType = contentType,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="LocalRedirectResult"/> with a 302 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="LocalRedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> LocalRedirectResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), false, false);
        }

        /// <summary>
        /// Yields a <see cref="LocalRedirectResult"/> with a 301 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="LocalRedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> LocalRedirectPermanentResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), true, false);
        }

        /// <summary>
        /// Yields a <see cref="LocalRedirectResult"/> with a 307 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="LocalRedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> LocalRedirectPermanentPreserveResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), true, true);
        }

        /// <summary>
        /// Yields a <see cref="LocalRedirectResult"/> with a 308 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="LocalRedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> LocalRedirectPreserveResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), false, true);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 302 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), false, false);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 301 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectPermanentResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), true, false);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 307 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectPermanentPreserveResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), true, true);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 308 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectPreserveResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new LocalRedirectResult(resultFunc.Invoke(response), false, true);
        }

        /// <summary>
        /// Yields a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, and <see cref="object"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues)> resultFunc)
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
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="object"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues, string Fragment)> resultFunc)
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
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, and <see cref="object"/> route values.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPermanentResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues)> resultFunc)
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
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="object"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPermanentResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues, string Fragment)> resultFunc)
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
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="object"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPermanentPreserveResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues, string Fragment)> resultFunc)
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
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> action name, <see cref="string"/> controller name, <see cref="object"/> route values, and <see cref="string"/> fragment.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectToActionResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectToActionPreserveResponse<TResponse>(Func<TResponse, (string ActionName, string ControllerName, object RouteValues, string Fragment)> resultFunc)
        {
            return response =>
            {
                var (actionName, controllerName, routeValues, fragment) = resultFunc.Invoke(response);

                return new RedirectToActionResult(actionName, controllerName, routeValues, true, false, fragment);
            };
        }

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
