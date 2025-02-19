// <copyright file="SuccessfulResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Successful responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="StatusCodeResult"/> of type 203 NonAuthoritative.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="StatusCodeResult"/>.</returns>
        public static Func<TResponse, IActionResult> NonAuthoritativeResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status203NonAuthoritative);
        }

        /// <summary>
        /// Yields a <see cref="NoContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="NoContentResult"/>.</returns>
        public static Func<TResponse, IActionResult> NoContentResponse<TResponse>()
        {
            return _ => new NoContentResult();
        }

        /// <summary>
        /// Yields a <see cref="StatusCodeResult"/> of type 205 ResetContent.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="StatusCodeResult"/>.</returns>
        public static Func<TResponse, IActionResult> ResetContentResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status205ResetContent);
        }

        /// <summary>
        /// Yields a <see cref="StatusCodeResult"/> of type 206 PartialContent.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="StatusCodeResult"/>.</returns>
        public static Func<TResponse, IActionResult> PartialContentResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status206PartialContent);
        }

        /// <summary>
        /// Yields a <see cref="StatusCodeResult"/> of type 207 MultiStatus.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="StatusCodeResult"/>.</returns>
        public static Func<TResponse, IActionResult> MultiStatusResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status207MultiStatus);
        }

        /// <summary>
        /// Yields a <see cref="StatusCodeResult"/> of type 208 AlreadyReported.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="StatusCodeResult"/>.</returns>
        public static Func<TResponse, IActionResult> AlreadyReportedResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status208AlreadyReported);
        }

        /// <summary>
        /// Yields a <see cref="StatusCodeResult"/> of type 226 IM Used.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="StatusCodeResult"/>.</returns>
        public static Func<TResponse, IActionResult> IMUsedResponse<TResponse>()
        {
            return _ => new StatusCodeResult(StatusCodes.Status226IMUsed);
        }
    }
}
