// <copyright file="AcceptedResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Accepted responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields an empty <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedEmpty<TResponse>()
        {
            return _ => new AcceptedResult();
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and location Func for the location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>()
        {
            return response => new AcceptedResult(string.Empty, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and location Func for the location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="locationFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="Uri"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, Uri> locationFunc)
        {
            return response => new AcceptedResult(locationFunc.Invoke(response), response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a <see cref="Func{TResult}"/> for the value and location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> with will yield a <see cref="Tuple"/> with a location <see cref="Uri"/> and <see cref="object"/>.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, (Uri Location, object Result)> responseFunc)
        {
            return response =>
            {
                var (location, result) = responseFunc.Invoke(response);

                return new AcceptedResult(location, result);
            };
        }
    }
}
