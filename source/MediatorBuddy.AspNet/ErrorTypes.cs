// <copyright file="ErrorTypes.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

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
        public virtual Uri General { get; set; } = new Uri("/Error/GeneralError", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative url of the operation could not be completed documentation.
        /// </summary>
        public virtual Uri OperationCouldNotBeCompleted { get; set; } = new Uri("/Error/OperationCouldNotBeCompleted", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative url of the entity was not found documentation.
        /// </summary>
        public virtual Uri EntityWasNotFound { get; set; } = new Uri("Error/EntityWasNotFound", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative url of the conflict with other resource documentation.
        /// </summary>
        public virtual Uri ConflictWithOtherResource { get; set; } = new Uri("Error/ConflictWithOtherResource", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative url of the validation constraint not met documentation.
        /// </summary>
        public virtual Uri ValidationConstraintNotMet { get; set; } = new Uri("Error/ValidationConstraintNotMet", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative url of auth error documentation.
        /// </summary>
        public virtual Uri Auth { get; set; } = new Uri("/errors/auth", UriKind.Relative);
    }
}
