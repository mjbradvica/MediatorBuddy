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
        /// Gets or sets the relative uri of general error documentation.
        /// </summary>
        public virtual Uri General { get; set; } = new Uri("/Error/GeneralError", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the operation could not be completed documentation.
        /// </summary>
        public virtual Uri OperationCouldNotBeCompleted { get; set; } = new Uri("/Error/OperationCouldNotBeCompleted", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the entity was not found documentation.
        /// </summary>
        public virtual Uri EntityWasNotFound { get; set; } = new Uri("Error/EntityWasNotFound", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the conflict with other resource documentation.
        /// </summary>
        public virtual Uri ConflictWithOtherResource { get; set; } = new Uri("Error/ConflictWithOtherResource", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the validation constraint not met documentation.
        /// </summary>
        public virtual Uri ValidationConstraintNotMet { get; set; } = new Uri("Error/ValidationConstraintNotMet", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the pre-condition not met documentation.
        /// </summary>
        public virtual Uri PreConditionNotMet { get; set; } = new Uri("Error/PreConditionNotMet", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the post-condition not met documentation.
        /// </summary>
        public virtual Uri PostConditionNotMet { get; set; } = new Uri("Error/PostConditionNotMet", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the could not process request documentation.
        /// </summary>
        public virtual Uri CouldNotProcessRequest { get; set; } = new Uri("Error/CouldNotProcessRequest", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of user does not exist documentation.
        /// </summary>
        public virtual Uri UserDoesNotExist { get; set; } = new Uri("Error/UserDoesNotExist", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of user could not be created documentation.
        /// </summary>
        public virtual Uri UserCouldNotBeCreated { get; set; } = new Uri("Error/UserCouldNotBeCreated", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the username already exists documentation.
        /// </summary>
        public virtual Uri UsernameAlreadyExists { get; set; } = new Uri("Error/UsernameAlreadyExists", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the email is already used documentation.
        /// </summary>
        public virtual Uri EmailIsAlreadyUsed { get; set; } = new Uri("Error/EmailIsAlreadyUsed", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the password is incorrect documentation.
        /// </summary>
        public virtual Uri PasswordIsIncorrect { get; set; } = new Uri("Error/PasswordIsIncorrect", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the password does not meet requirements documentation.
        /// </summary>
        public virtual Uri PasswordDoesNotMeetRequirements { get; set; } = new Uri("Error/PasswordDoesNotMeetRequirements", UriKind.Relative);

        /// <summary>
        /// Gets or sets the relative uri of the too many recent attempts documentation.
        /// </summary>
        public virtual Uri TooManyRecentAttempts { get; set; } = new Uri("Error/TooManyRecentAttempts", UriKind.Relative);

        /// <summary>
        /// Gets or sets the account is locked out documentation.
        /// </summary>
        public virtual Uri AccountIsLockedOut { get; set; } = new Uri("Error/AccountIsLockedOut", UriKind.Relative);

        /// <summary>
        /// Gets or sets the account has not been verified documentation.
        /// </summary>
        public virtual Uri AccountHasNotBeenVerified { get; set; } = new Uri("Error/AccountHasNotBeenVerified", UriKind.Relative);

        /// <summary>
        /// Gets or sets the email has not been verified documentation.
        /// </summary>
        public virtual Uri EmailHasNotBeenVerified { get; set; } = new Uri("Error/EmailHasNotBeenVerified", UriKind.Relative);

        /// <summary>
        /// Gets or sets the two-factor code incorrect documentation.
        /// </summary>
        public virtual Uri TwoFactorCodeIncorrect { get; set; } = new Uri("Error/TwoFactorCodeIncorrect", UriKind.Relative);

        /// <summary>
        /// Gets or sets the unauthorized user documentation.
        /// </summary>
        public virtual Uri UnauthorizedUser { get; set; } = new Uri("Error/UnauthorizedUser", UriKind.Relative);

        /// <summary>
        /// Gets or sets the content is forbidden documentation.
        /// </summary>
        public virtual Uri ContentIsForbidden { get; set; } = new Uri("Error/ContentIsForbidden", UriKind.Relative);

        /// <summary>
        /// Gets or sets the general auth error.
        /// </summary>
        public virtual Uri GeneralAuthError { get; set; } = new Uri("Error/GeneralAuthError", UriKind.Relative);

        /// <summary>
        /// Gets or sets the authentication challenged error.
        /// </summary>
        public virtual Uri AuthenticationChallenged { get; set; } = new Uri("Error/AuthenticationChallenged", UriKind.Relative);
    }
}
