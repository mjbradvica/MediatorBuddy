namespace NMediatController
{
    using System;
    using MediatR;

    public class GlobalExceptionOccurred : INotification
    {
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }
    }
}
