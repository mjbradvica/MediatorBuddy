// <copyright file="ContentResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Content responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="ContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="int"/> status code, <see cref="string"/> content value, and <see cref="string"/> content type.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ContentResult"/>.</returns>
        public static Func<TResponse, IActionResult> ContentResponse<TResponse>(Func<TResponse, (int StatusCode, string Content, string ContentType)> resultFunc)
        {
            return response =>
            {
                var (statusCode, content, contentType) = resultFunc.Invoke(response);

                return new ContentResult
                {
                    StatusCode = statusCode,
                    Content = content,
                    ContentType = contentType,
                };
            };
        }
    }
}
