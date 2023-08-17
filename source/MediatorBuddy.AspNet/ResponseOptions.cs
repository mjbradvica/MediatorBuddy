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
        public static Func<IEnvelope<TResponse>, IActionResult> ContinueResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new StatusCodeResult(StatusCodes.Status100Continue));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 101 Switching Protocols.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>An function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> SwitchingProtocolsResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new StatusCodeResult(StatusCodes.Status101SwitchingProtocols));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="StatusCodeResult"/> of type 102 Processing.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> ProcessingResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new StatusCodeResult(StatusCodes.Status102Processing));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="OkResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type OkResponse.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> OkResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new OkResult());
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="OkObjectResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type OkObjectResponse.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> OkObjectResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new OkObjectResult(envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="location">The Uri where the resource can be accessed.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResponse.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> CreatedResponse<TResponse>(Uri location)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new CreatedResult(location, envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="location">A string that represents a Uri location of the resource.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedResult..</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> CreatedResponse<TResponse>(string location)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new CreatedResult(location, envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="actionName">The name of the controller action.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type CreatedAtActionResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> CreatedAtActionResponse<TResponse>(string actionName, string controllerName, Func<TResponse, object> routeValuesFunc)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new CreatedAtActionResult(actionName, controllerName, routeValuesFunc.Invoke(envelope.Response), envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <returns>A function that will return an IActionResult of type CreatedAtRouteResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> CreatedAtRouteResponse<TResponse>(Func<TResponse, object> routeValuesFunc)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new CreatedAtRouteResult(routeValuesFunc.Invoke(envelope.Response), envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="routeName">The name of the route where the response object may be found.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <returns>A function that will return an IActionResult of type CreatedAtRouteResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> CreatedAtRouteResponse<TResponse>(string routeName, Func<TResponse, object> routeValuesFunc)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new CreatedAtRouteResult(routeName, routeValuesFunc.Invoke(envelope.Response), envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield at <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> AcceptedResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new AcceptedResult());
        }

        /// <summary>
        /// Returns a function that will yield at <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="Uri"/> with the location of the resource.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> AcceptedResponse<TResponse>(Uri location)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new AcceptedResult(location, envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield at <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="string"/> with the location of the resource.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> AcceptedResponse<TResponse>(string location)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new AcceptedResult(location, envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <param name="actionName">The name of the controller action.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type AcceptedAtActionResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> AcceptedAtActionResponse<TResponse>(string actionName, string controllerName, Func<TResponse, object> routeValuesFunc)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new AcceptedAtActionResult(actionName, controllerName, routeValuesFunc.Invoke(envelope.Response), envelope.Response));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="routeName">The name of the route where the response object may be found.</param>
        /// <param name="routeValuesFunc">A func that will return a routeValues object.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedAtRouteResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> AcceptedAtRouteResponse<TResponse>(string routeName, Func<TResponse, object> routeValuesFunc)
        {
            return envelope => DetermineResponse(envelope.StatusCode, new AcceptedAtRouteResult(routeName, routeValuesFunc.Invoke(envelope.Response), envelope.Response));
        }

        /// <summary>
        /// Returns that function that will yield a <see cref="StatusCodeResult"/> of type 203 NonAuthoritative.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> NonAuthoritativeResponse<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new StatusCodeResult(StatusCodes.Status203NonAuthoritative));
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="NoContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A function that will return an IActionResult of type NoContentResult.</returns>
        public static Func<IEnvelope<TResponse>, IActionResult> NoContent<TResponse>()
        {
            return envelope => DetermineResponse(envelope.StatusCode, new NoContentResult());
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

        /// <summary>
        /// Tester func.
        /// </summary>
        /// <returns>Func.</returns>
        public static IActionResult Tester()
        {
            // int code = StatusCodes.Status300MultipleChoices;
            return new OkResult();
        }
    }
}
