using System;

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
        /// Gets a human readable message about the error.
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
    }
}
