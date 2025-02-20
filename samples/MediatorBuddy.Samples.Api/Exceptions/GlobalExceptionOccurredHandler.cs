// <copyright file="GlobalExceptionOccurredHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatR;

namespace MediatorBuddy.Samples.Api.Exceptions
{
    /// <summary>
    /// Handle class for global exceptions.
    /// </summary>
    public class GlobalExceptionOccurredHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionOccurredHandler"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger"/> interface.</param>
        public GlobalExceptionOccurredHandler(ILogger<GlobalExceptionOccurredHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles a global exception notification.
        /// </summary>
        /// <param name="notification">The notification event.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            _logger.LogError(notification.Exception, message: "Global exception at {dateTime}", notification.DateTimeOffset);

            return Task.CompletedTask;
        }
    }
}
