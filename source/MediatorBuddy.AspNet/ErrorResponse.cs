// <copyright file="ErrorResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A standardized error response based off the RFC 7807 standard.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        /// <param name="type">The error category.</param>
        /// <param name="title">A short description of the title.</param>
        /// <param name="status">The status code of the error.</param>
        /// <param name="detail">A detailed description of the error.</param>
        /// <param name="instance">Where the error originated from.</param>
        public ErrorResponse(Uri type, string title, int status, string detail, Uri instance)
        {
            Type = type;
            Title = title;
            Status = status;
            Detail = detail;
            Instance = instance;
        }

        /// <summary>
        /// Gets a Uri identifier that categorizes the error.
        /// </summary>
        public Uri Type { get; }

        /// <summary>
        /// Gets a human read-able message about the error.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets a detailed explanation of the error.
        /// </summary>
        public string Detail { get; }

        /// <summary>
        /// Gets a Uri that identifies where the error occurred.
        /// </summary>
        public Uri Instance { get; }

        /// <summary>
        /// Instantiates an instance of the <see cref="ErrorResponse"/> class or a specified error.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="type">The error type uri.</param>
        /// <param name="statusCode">The http status code.</param>
        /// <param name="envelope">The response envelope.</param>
        /// <param name="instance">The action uri.</param>
        /// <returns>A new ErrorResponse instance.</returns>
        public static ErrorResponse FromEnvelope<TResponse>(Uri type, int statusCode, IEnvelope<TResponse> envelope, Uri instance)
        {
            return new ErrorResponse(type, envelope.Title, statusCode, envelope.Detail, instance);
        }

        /// <summary>
        /// Instantiates an instance of the <see cref="ErrorResponse"/> class for a validation error.
        /// </summary>
        /// <param name="type">The error type uri.</param>
        /// <param name="errors">A list of validation errors.</param>
        /// <param name="instance">The action uri.</param>
        /// <returns>A new ErrorResponse instance.</returns>
        public static ErrorResponse ValidationError(Uri type, IEnumerable<string> errors, Uri instance)
        {
            return new ErrorResponse(
                type,
                "Validation Error",
                StatusCodes.Status400BadRequest,
                $"The follow errors were present: {errors.Aggregate((final, next) => $"{final} {next}")}",
                instance);
        }

        /// <summary>
        /// Instantiates an instance of the <see cref="ErrorResponse"/> for an internal error.
        /// </summary>
        /// <param name="type">The error type uri.</param>
        /// <param name="instance">The action uri.</param>
        /// <returns>A new Error Response instance.</returns>
        public static ErrorResponse InternalError(Uri type, Uri instance)
        {
            return new ErrorResponse(
                type,
                "An internal error occurred",
                StatusCodes.Status500InternalServerError,
                "An error occurred during the operation. It's not you, it's me.",
                instance);
        }
    }
}
