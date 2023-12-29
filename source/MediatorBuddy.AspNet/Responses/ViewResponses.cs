// <copyright file="ViewResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// View responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, IActionResult> ViewResponse<TResponse>()
        {
            return response =>
            {
                return new ViewResult
                {
                };
            };
        }
    }
}
