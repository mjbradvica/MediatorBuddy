// <copyright file="Envelope.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy
{
    /// <summary>
    /// A class to wrap response in.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    public class Envelope<TResponse> : IEnvelope<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="response">The response object.</param>
        public Envelope(TResponse response)
        {
            Response = response;
            Status = ApplicationStatus.Success;
            Title = string.Empty;
            Detail = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        public Envelope(int statusCode, string title, string detail)
        {
            Status = statusCode;
            Response = default!;
            Title = title;
            Detail = detail;
        }

        /// <inheritdoc/>
        public int Status { get; }

        /// <inheritdoc/>
        public string Title { get; }

        /// <inheritdoc/>
        public string Detail { get; }

        /// <inheritdoc/>
        public TResponse Response { get; }

        /// <summary>
        /// Factory function for success Envelope..
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>A new response Envelope.</returns>
        public static Envelope<TResponse> Success(TResponse response)
        {
            return new Envelope<TResponse>(response);
        }

        /// <summary>
        /// Factory function for a failed Envelope.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static Envelope<TResponse> Failure(int statusCode, string title = "A failure occurred.", string detail = "No details are available for the failure.")
        {
            return new Envelope<TResponse>(statusCode, title, detail);
        }
    }
}
