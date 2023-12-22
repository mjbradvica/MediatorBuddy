// <copyright file="OkResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Conflict responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields an empty <see cref="OkResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="OkResult"/>.</returns>
        public static Func<TResponse, IActionResult> OkEmpty<TResponse>()
        {
            return _ => new OkResult();
        }

        /// <summary>
        /// Yields a <see cref="OkObjectResult"/> with a static <see cref="object"/> as the value.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="response">A static <see cref="object"/> for the response.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="OkObjectResult"/>.</returns>
        public static Func<TResponse, IActionResult> OkResponse<TResponse>(object response)
        {
            return _ => new OkObjectResult(response);
        }

        /// <summary>
        /// Yields a <see cref="OkObjectResult"/> with the response as the value.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="OkObjectResult"/>.</returns>
        public static Func<TResponse, IActionResult> OkResponse<TResponse>()
        {
            return response => new OkObjectResult(response);
        }

        /// <summary>
        /// Yields a <see cref="OkObjectResult"/> with the response from a <see cref="Func{TResult}"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> that yields an object from the response.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="OkObjectResult"/>.</returns>
        public static Func<TResponse, IActionResult> OkResponse<TResponse>(Func<TResponse, object> responseFunc)
        {
            return response => new OkObjectResult(responseFunc.Invoke(response));
        }
    }
}
