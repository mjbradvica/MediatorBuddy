// <copyright file="CustomErrorWrapper.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A wrapper for custom error properties.
    /// </summary>
    public class CustomErrorWrapper
    {
        private CustomErrorWrapper(int status, string title, string detail, Uri instance, ErrorTypes errorTypes)
        {
            Status = status;
            Title = title;
            Detail = detail;
            Instance = instance;
            ErrorTypes = errorTypes;
        }

        /// <summary>
        /// Gets the application status.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets the error title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the error detail.
        /// </summary>
        public string Detail { get; }

        /// <summary>
        /// Gets the error types.
        /// </summary>
        public ErrorTypes ErrorTypes { get; }

        /// <summary>
        /// Gets the current endpoint instance.
        /// </summary>
        public Uri Instance { get; }

        /// <summary>
        /// Creates a new custom error wrapper.
        /// </summary>
        /// <param name="status">The application status.</param>
        /// <param name="title">The error title.</param>
        /// <param name="detail">The error details.</param>
        /// <param name="instance">The current endpoint instance.</param>
        /// <param name="errorTypes">The error types instance.</param>
        /// <returns>A new <see cref="CustomErrorWrapper"/>.</returns>
        public static CustomErrorWrapper Instantiate(int status, string title, string detail, Uri instance, ErrorTypes errorTypes)
        {
            return new CustomErrorWrapper(status, title, detail, instance, errorTypes);
        }
    }
}
