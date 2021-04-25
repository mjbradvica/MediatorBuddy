namespace NMediatController
{
    using System;

    public class GlobalExceptionOccurred
    {
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }
    }
}
