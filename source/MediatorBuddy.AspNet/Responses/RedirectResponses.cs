// <copyright file="RedirectResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Redirect responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 302 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new RedirectResult(resultFunc.Invoke(response), false, false);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 301 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectPermanentResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new RedirectResult(resultFunc.Invoke(response), true, false);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 307 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectPermanentPreserveResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new RedirectResult(resultFunc.Invoke(response), true, true);
        }

        /// <summary>
        /// Yields a <see cref="RedirectResult"/> with a 308 status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> for a local url.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="RedirectResult"/>.</returns>
        public static Func<TResponse, IActionResult> RedirectPreserveResponse<TResponse>(Func<TResponse, string> resultFunc)
        {
            return response => new RedirectResult(resultFunc.Invoke(response), false, true);
        }
    }
}
