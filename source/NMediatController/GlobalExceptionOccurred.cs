using System;
using MediatR;

namespace NMediatController
{
    /// <summary>
    /// A class designating a global exception occurred during a request lifecycle.
    /// </summary>
    public class GlobalExceptionOccurred : INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionOccurred"/> class.
        /// </summary>
        /// <param name="exception">The exception that was thrown during a request process.</param>
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception that occurred during a request.
        /// </summary>
        public Exception Exception { get; }
    }
}
