// <copyright file="RazorErrorWrapper.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>


/* Unmerged change from project 'MediatorBuddy.AspNet (netstandard2.1)'
Before:
namespace MediatorBuddy.AspNet.Mvc
After:
using MediatorBuddy;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Mvc
*/

// <copyright file="RazorErrorWrapper.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
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
