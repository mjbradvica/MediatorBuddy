using System;

namespace NMediatController
{
    /// <summary>
    /// A class to wrap response in.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    public class Envelope<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="response">The response object.</param>
        public Envelope(TResponse response)
        {
            Response = response;
            IsSuccess = true;
            StatusCode = ApplicationStatus.Success;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        public Envelope(int statusCode)
        {
            IsSuccess = false;
            StatusCode = statusCode;
            Response = default!;
        }

        /// <summary>
        /// Gets a value indicating whether a response was a success.
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets the StatusCode of the Envelope.
        /// </summary>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Gets the Response object from the Envelope.
        /// </summary>
        public TResponse Response { get; private set; }

        /// <summary>
        /// Factory function for Envelope class.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>A new response object.</returns>
        public static Envelope<TResponse> Success(TResponse response)
        {
            return new Envelope<TResponse>(response);
        }

        /// <summary>
        /// Failure of an incorrect password
        /// </summary>
        /// <returns>A failed envelope.</returns>
        public static Envelope<TResponse> IncorrectPassword()
        {
            return new Envelope<TResponse>(55);
        }
    }
}
