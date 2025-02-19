// <copyright file="ErrorTypes.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// Default values for error type documentation.
    /// </summary>
    public class ErrorTypes
    {
        /// <summary>
        /// Gets the relative uri of general error documentation.
        /// </summary>
        public virtual Uri General { get; } = new Uri("/Error/GeneralError", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the operation could not be completed documentation.
        /// </summary>
        public virtual Uri OperationCouldNotBeCompleted { get; } = new Uri("/Error/OperationCouldNotBeCompleted", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the entity was not found documentation.
        /// </summary>
        public virtual Uri EntityWasNotFound { get; } = new Uri("Error/EntityWasNotFound", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the conflict with other resource documentation.
        /// </summary>
        public virtual Uri ConflictWithOtherResource { get; } = new Uri("Error/ConflictWithOtherResource", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the validation constraint not met documentation.
        /// </summary>
        public virtual Uri ValidationConstraintNotMet { get; } = new Uri("Error/ValidationConstraintNotMet", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the pre-condition not met documentation.
        /// </summary>
        public virtual Uri PreConditionNotMet { get; } = new Uri("Error/PreConditionNotMet", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the post-condition not met documentation.
        /// </summary>
        public virtual Uri PostConditionNotMet { get; } = new Uri("Error/PostConditionNotMet", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the could not process request documentation.
        /// </summary>
        public virtual Uri CouldNotProcessRequest { get; } = new Uri("Error/CouldNotProcessRequest", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of user does not exist documentation.
        /// </summary>
        public virtual Uri UserDoesNotExist { get; } = new Uri("Error/UserDoesNotExist", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of user could not be created documentation.
        /// </summary>
        public virtual Uri UserCouldNotBeCreated { get; } = new Uri("Error/UserCouldNotBeCreated", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the username already exists documentation.
        /// </summary>
        public virtual Uri UsernameAlreadyExists { get; } = new Uri("Error/UsernameAlreadyExists", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the email is already used documentation.
        /// </summary>
        public virtual Uri EmailIsAlreadyUsed { get; } = new Uri("Error/EmailIsAlreadyUsed", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the password is incorrect documentation.
        /// </summary>
        public virtual Uri PasswordIsIncorrect { get; } = new Uri("Error/PasswordIsIncorrect", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the password does not meet requirements documentation.
        /// </summary>
        public virtual Uri PasswordDoesNotMeetRequirements { get; } = new Uri("Error/PasswordDoesNotMeetRequirements", UriKind.Relative);

        /// <summary>
        /// Gets the relative uri of the too many recent attempts documentation.
        /// </summary>
        public virtual Uri TooManyRecentAttempts { get; } = new Uri("Error/TooManyRecentAttempts", UriKind.Relative);

        /// <summary>
        /// Gets the account is locked out documentation.
        /// </summary>
        public virtual Uri AccountIsLockedOut { get; } = new Uri("Error/AccountIsLockedOut", UriKind.Relative);

        /// <summary>
        /// Gets the account has not been verified documentation.
        /// </summary>
        public virtual Uri AccountHasNotBeenVerified { get; } = new Uri("Error/AccountHasNotBeenVerified", UriKind.Relative);

        /// <summary>
        /// Gets the email has not been verified documentation.
        /// </summary>
        public virtual Uri EmailHasNotBeenVerified { get; } = new Uri("Error/EmailHasNotBeenVerified", UriKind.Relative);

        /// <summary>
        /// Gets the two-factor code incorrect documentation.
        /// </summary>
        public virtual Uri TwoFactorCodeIncorrect { get; } = new Uri("Error/TwoFactorCodeIncorrect", UriKind.Relative);

        /// <summary>
        /// Gets the unauthorized user documentation.
        /// </summary>
        public virtual Uri UnauthorizedUser { get; } = new Uri("Error/UnauthorizedUser", UriKind.Relative);

        /// <summary>
        /// Gets the content is forbidden documentation.
        /// </summary>
        public virtual Uri ContentIsForbidden { get; } = new Uri("Error/ContentIsForbidden", UriKind.Relative);

        /// <summary>
        /// Gets the general auth error.
        /// </summary>
        public virtual Uri GeneralAuthError { get; } = new Uri("Error/GeneralAuthError", UriKind.Relative);

        /// <summary>
        /// Gets the authentication challenged error.
        /// </summary>
        public virtual Uri AuthenticationChallenged { get; } = new Uri("Error/AuthenticationChallenged", UriKind.Relative);
    }
}
