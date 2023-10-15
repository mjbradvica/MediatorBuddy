// <copyright file="ResponseOptions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A collection of functions that provide basic responses for a given status code.
    /// </summary>
    public static class ResponseOptions
    {
        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 100 Continue.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> ContinueResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status100Continue);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 101 Switching Protocols.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>An function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> SwitchingProtocolsResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status101SwitchingProtocols);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 102 Processing.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> ProcessingResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status102Processing);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="OkResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type OkResponse.</returns>
        public static Func<TResponse, IActionResult> OkResponse<TResponse>()
        {
            return _ => new OkResult();
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="OkObjectResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type OkObjectResponse.</returns>
        public static Func<TResponse, IActionResult> OkObjectResponse<TResponse>()
        {
            return response => new OkObjectResult(response);
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
        /// <returns>A function that will return an IActionResult of type CreatedResult..</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(string location)
        {
            return response => new CreatedResult(location, response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="locationFunc">A string that represents a Uri location of the resource.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResult..</returns>
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
        /// Returns a function that will yield at <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>()
        {
            return _ => new AcceptedResult();
        }

        /// <summary>
        /// Returns a function that will yield at <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="Uri"/> with the location of the resource.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Uri location)
        {
            return response => new AcceptedResult(location, response);
        }

        /// <summary>
        /// Returns a function that will yield at <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="string"/> with the location of the resource.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(string location)
        {
            return response => new AcceptedResult(location, response);
        }

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
        /// Returns that function that will yield a <see cref="StatusCodeResult"/> of type 203 NonAuthoritative.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> NonAuthoritativeResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status203NonAuthoritative);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="NoContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type NoContentResult.</returns>
        public static Func<TResponse, IActionResult> NoContentResponse<TResponse>()
        {
            return _ => new NoContentResult();
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 205 ResetContent.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> ResetContentResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status205ResetContent);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 206 PartialContent.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> PartialContentResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status206PartialContent);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 207 MultiStatus.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> MultiStatusResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status207MultiStatus);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 208 AlreadyReported.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<TResponse, IActionResult> AlreadyReportedResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status208AlreadyReported);
        }
    }
}
