using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NMediatController.ASPNET
{
    /// <summary>
    /// A collection of functions that provide basic responses for a given status code.
    /// </summary>
    public static class ResponseOptions
    {
        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 100 Continue.
        /// </summary>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<ApplicationResponse, IActionResult> ContinueResponse()
        {
            return response => DetermineResponse(response.StatusCode, new StatusCodeResult(StatusCodes.Status100Continue));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 101 Switching Protocols.
        /// </summary>
        /// <returns>An function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<ApplicationResponse, IActionResult> SwitchingProtocolsResponse()
        {
            return response => DetermineResponse(response.StatusCode, new StatusCodeResult(StatusCodes.Status101SwitchingProtocols));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 102 Processing.
        /// </summary>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<ApplicationResponse, IActionResult> ProcessingResponse()
        {
            return response => DetermineResponse(response.StatusCode, new StatusCodeResult(StatusCodes.Status102Processing));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="OkObjectResult"/>.
        /// </summary>
        /// <returns>A function that will return an IActionResult of type OkObjectResponse.</returns>
        public static Func<ApplicationResponse, IActionResult> OkObjectResponse()
        {
            return response => DetermineResponse(response.StatusCode, new OkObjectResult(response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="OkResult"/>.
        /// </summary>
        /// <returns>A function that will return an IActionResult of type OkResponse.</returns>
        public static Func<ApplicationResponse, IActionResult> OkResponse()
        {
            return response => DetermineResponse(response.StatusCode, new OkResult());
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="location">The Uri where the resource can be accessed.</param>
        /// <returns>A function that will return an IActionResult of type CreatedResponse.</returns>
        public static Func<ApplicationResponse, IActionResult> CreatedResponse(Uri location)
        {
            return response => DetermineResponse(response.StatusCode, new CreatedResult(location, response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="location">A string that represents a Uri location of the resource.</param>
        /// <returns>A function that will return an IActionResult of type CreatedResult..</returns>
        public static Func<ApplicationResponse, IActionResult> CreatedResponse(string location)
        {
            return response => DetermineResponse(response.StatusCode, new CreatedResult(location, response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="actionName">The name of the controller action.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object containing any route values.</param>
        /// <returns>A function that will return an IActionResult of type CreatedAtActionResult.</returns>
        public static Func<ApplicationResponse, IActionResult> CreatedAtActionResponse(string actionName, string controllerName, object routeValues)
        {
            return response => DetermineResponse(response.StatusCode, new CreatedAtActionResult(actionName, controllerName, routeValues, response));
        }

        /// <summary>
        /// A function that accepts a StatusCode and Result object and returns the appropriate response.
        /// </summary>
        /// <param name="statusCode">An application level status code.</param>
        /// <param name="result">The result object from a handler.</param>
        /// <param name="additionalOptions">Any additional response actions that may be required.</param>
        /// <returns>An IActionResult with the appropriate response.</returns>
        public static IActionResult DetermineResponse(int statusCode, IActionResult result, Func<int, IActionResult>? additionalOptions = null)
        {
            if (additionalOptions != null)
            {
                return additionalOptions.Invoke(statusCode);
            }

            return statusCode switch
            {
                ApplicationStatus.Success => result,
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
            };
        }
    }
}
