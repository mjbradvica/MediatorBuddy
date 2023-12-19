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
    }
}
