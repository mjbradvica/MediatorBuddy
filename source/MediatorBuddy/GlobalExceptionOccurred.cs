// <copyright file="GlobalExceptionOccurred.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using MediatR;

namespace MediatorBuddy
{
    /// <summary>
    /// A class designating a global exception occurred during a request lifecycle.
    /// </summary>
    public class GlobalExceptionOccurred : INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionOccurred"/> class.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> that was thrown during a request process.</param>
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
            DateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the exception that occurred during a request.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets a time stamp when the exception occurred.
        /// </summary>
        public DateTime DateTime { get; }
    }
}
