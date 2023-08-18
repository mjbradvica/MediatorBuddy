using System;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// Default values for error type documentation.
    /// </summary>
    public class ErrorTypes
    {
        /// <summary>
        /// Gets or sets the relative url of general error documentation.
        /// </summary>
        public Uri General { get; set; } = new Uri("/errors/general", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative url of auth error documentation.
        /// </summary>
        public Uri Auth { get; set; } = new Uri("/errors/auth", UriKind.Relative);
    }
}
