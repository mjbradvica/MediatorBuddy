// <copyright file="CreatedResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Created responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="CreatedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedEmptyResponse<TResponse>()
        {
            return _ => new CreatedResult(string.Empty, null);
        }

        /// <summary>
        /// Yields a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="locationFunc">A <see cref="Uri"/> where the resource can be accessed.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(Func<TResponse, Uri> locationFunc)
        {
            return response => new CreatedResult(locationFunc.Invoke(response), response);
        }

        /// <summary>
        /// Returns a function that will yield a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="Uri"/> location and <see cref="object"/> value.</param>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="CreatedResult"/>.</returns>
        public static Func<TResponse, IActionResult> CreatedResponse<TResponse>(Func<TResponse, (Uri Location, object Value)> resultFunc)
        {
            return response =>
            {
                var (location, value) = resultFunc.Invoke(response);

                return new CreatedResult(location, value);
            };
        }
    }
}
