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
        /// Returns an OkObject result on success.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>An OkObjectResult.</returns>
        public static IActionResult OkObjectResult(ApplicationResponse response)
        {
            return DetermineResponse(response, new OkObjectResult(response));
        }

        private static IActionResult DetermineResponse(ApplicationResponse response, IActionResult result)
        {
            return response.StatusCode switch
            {
                ApplicationStatus.Success => result,
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
            };
        }
    }
}
