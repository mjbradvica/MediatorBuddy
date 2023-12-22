// <copyright file="InformationResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Information responses.
    /// </summary>
    public static partial class ResponseOptions
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
        /// <returns>A function that will return an IActionResult of type StatusCodeResult.</returns>
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
    }
}
