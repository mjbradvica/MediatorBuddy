// <copyright file="RazorErrorWrapper.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// Error wrapper for razor based frameworks.
    /// </summary>
    public class RazorErrorWrapper
    {
        private RazorErrorWrapper(int applicationStatus, string title, string detail)
        {
            ApplicationStatus = applicationStatus;
            Title = title;
            Detail = detail;
        }

        /// <summary>
        /// Gets the application status.
        /// </summary>
        public int ApplicationStatus { get; }

        /// <summary>
        /// Gets the error title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the error details.
        /// </summary>
        public string Detail { get; }

        /// <summary>
        /// Instantiates the error wrapper.
        /// </summary>
        /// <param name="applicationStatus">The application status.</param>
        /// <param name="title">The error title.</param>
        /// <param name="detail">The error details.</param>
        /// <returns>A new <see cref="RazorErrorWrapper"/>.</returns>
        public static RazorErrorWrapper Instantiate(int applicationStatus, string title, string detail)
        {
            return new RazorErrorWrapper(applicationStatus, title, detail);
        }
    }
}
