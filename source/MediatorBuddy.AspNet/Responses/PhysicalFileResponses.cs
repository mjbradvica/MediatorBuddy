// <copyright file="PhysicalFileResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Physical file responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="PhysicalFileResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> physical path, <see cref="string"/> content type, <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entity tag, and <see cref="bool"/> enable range processing. </param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PhysicalFileResult"/>.</returns>
        public static Func<TResponse, IActionResult> PhysicalFileResponse<TResponse>(Func<TResponse, (string PhysicalPath, string ContentType, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (physicalPath, contentType, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new PhysicalFileResult(physicalPath, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PhysicalFileResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> physical path, <see cref="string"/> content type, <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entity tag, and <see cref="bool"/> enable range processing. </param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PhysicalFileResult"/>.</returns>
        public static Func<TResponse, IActionResult> PhysicalFileResponse<TResponse>(Func<TResponse, (string PhysicalPath, string ContentType, string FileDownloadName, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (physicalPath, contentType, fileDownloadName, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new PhysicalFileResult(physicalPath, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                    FileDownloadName = fileDownloadName,
                };
            };
        }
    }
}
