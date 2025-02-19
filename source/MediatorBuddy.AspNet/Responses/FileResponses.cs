// <copyright file="FileResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// File responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="FileContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="Array"/> of type <see cref="byte"/> file contents, <see cref="string"/> content type, nullable <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entitty tag, and <see cref="bool"/> enable range processing.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="FileContentResult"/>.</returns>
        public static Func<TResponse, IActionResult> FileContentResponse<TResponse>(
            Func<TResponse, (byte[] FileContents, string ContentType, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (fileContents, contentType, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new FileContentResult(fileContents, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="FileContentResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="Array"/> of type <see cref="byte"/> file contents, <see cref="string"/> file download name, <see cref="string"/> content type, nullable <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entitty tag, and <see cref="bool"/> enable range processing.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="FileContentResult"/>.</returns>
        public static Func<TResponse, IActionResult> FileContentResponse<TResponse>(
            Func<TResponse, (byte[] FileContents, string ContentType, string FileDownloadName, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (fileContents, contentType, fileDownloadName, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new FileContentResult(fileContents, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                    FileDownloadName = fileDownloadName,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="FileStreamResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="Stream"/> file stream, <see cref="string"/> content type, nullable <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entitty tag, and <see cref="bool"/> enable range processing.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="FileStreamResult"/>.</returns>
        public static Func<TResponse, IActionResult> FileStreamResponse<TResponse>(
            Func<TResponse, (Stream FileStream, string ContentType, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (fileStream, contentType, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new FileStreamResult(fileStream, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="FileStreamResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="Stream"/> file stream, <see cref="string"/> file download name, <see cref="string"/> content type, nullable <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entitty tag, and <see cref="bool"/> enable range processing.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="FileStreamResult"/>.</returns>
        public static Func<TResponse, IActionResult> FileStreamResponse<TResponse>(
            Func<TResponse, (Stream FileStream, string ContentType, string FileDownloadName, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (fileStream, contentType, fileDownloadName, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new FileStreamResult(fileStream, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                    FileDownloadName = fileDownloadName,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="VirtualFileResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> virtual path, <see cref="string"/> content type, nullable <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entitty tag, and <see cref="bool"/> enable range processing.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="VirtualFileResult"/>.</returns>
        public static Func<TResponse, IActionResult> VirtualFileResponse<TResponse>(
            Func<TResponse, (string VirtualPath, string ContentType, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (virtualPath, contentType, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new VirtualFileResult(virtualPath, contentType)
                {
                    LastModified = lastModified,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="VirtualFileResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that yields a <see cref="string"/> virtual path, <see cref="string"/> file download name, <see cref="string"/> content type, nullable <see cref="DateTimeOffset"/> last modified, <see cref="EntityTagHeaderValue"/> entitty tag, and <see cref="bool"/> enable range processing.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="VirtualFileResult"/>.</returns>
        public static Func<TResponse, IActionResult> VirtualFileResponse<TResponse>(
            Func<TResponse, (string VirtualPath, string ContentType, string FileDownloadName, DateTimeOffset? LastModified, EntityTagHeaderValue? EntityTag, bool EnableRangeProcessing)> resultFunc)
        {
            return response =>
            {
                var (virtualPath, contentType, fileDownloadName, lastModified, entityTag, enableRangeProcessing) = resultFunc.Invoke(response);

                return new VirtualFileResult(virtualPath, contentType)
                {
                    LastModified = lastModified,
                    FileDownloadName = fileDownloadName,
                    EntityTag = entityTag,
                    EnableRangeProcessing = enableRangeProcessing,
                };
            };
        }
    }
}
