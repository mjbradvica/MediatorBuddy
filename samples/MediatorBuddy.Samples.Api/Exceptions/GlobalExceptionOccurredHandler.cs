using MediatR;

namespace MediatorBuddy.Samples.Api.Exceptions
{
    public class GlobalExceptionOccurredHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        private readonly ILogger _logger;

        public GlobalExceptionOccurredHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            _logger.LogError(notification.Exception, message: "Global exception at {dateTime}", notification.DateTime);

            return Task.CompletedTask;
        }
    }
}
