// <copyright file="ApplicationStatus.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy
{
    /// <summary>
    /// Defines that class that contains status codes used to designate the status of the application.
    /// </summary>
    public partial class ApplicationStatus
    {
        /// <summary>
        /// Indicates an operation was successful.
        /// </summary>
        public const int Success = 0;

        /// <summary>
        /// Indicates a non descriptive error.
        /// </summary>
        public const int GeneralError = 1;

        /// <summary>
        /// The operation could not be completed at this time.
        /// </summary>
        public const int OperationCouldNotBeCompleted = 2;

        /// <summary>
        /// The Entity in question was not found.
        /// </summary>
        public const int EntityWasNotFound = 4;

        /// <summary>
        /// Indicates a conflict was found with another resource.
        /// </summary>
        public const int ConflictWithOtherResource = 5;

        /// <summary>
        /// A validation constraint was not met.
        /// </summary>
        public const int ValidationConstraintNotMet = 3;

        /// <summary>
        /// Indicates a pre-condition constraint failed.
        /// </summary>
        public const int PreConditionNotMet = 6;

        /// <summary>
        /// Indicates a post-condition constraint failed.
        /// </summary>
        public const int PostConditionNotMet = 7;

        // Authentication

        /// <summary>
        /// The User could not be found.
        /// </summary>
        public const int UserDoesNotExist = 30;

        /// <summary>
        /// The User was unable to be created.
        /// </summary>
        public const int UserCouldNotBeCreated = 31;

        /// <summary>
        /// The username already exists.
        /// </summary>
        public const int UsernameAlreadyExists = 32;

        /// <summary>
        /// The email is already in use.
        /// </summary>
        public const int EmailIsAlreadyUsed = 33;

        /// <summary>
        /// The password given was incorrect.
        /// </summary>
        public const int PasswordIsIncorrect = 34;

        /// <summary>
        /// The password does not meet all the requirements.
        /// </summary>
        public const int PasswordDoesNotMeetRequirements = 35;

        /// <summary>
        /// The User has made too many attempts recently.
        /// </summary>
        public const int TooManyRecentAttempts = 36;

        /// <summary>
        /// The User is currently locked out of their account.
        /// </summary>
        public const int AccountIsLockedOut = 37;

        /// <summary>
        /// The account has yet to be verified.
        /// </summary>
        public const int AccountHasNotBeenVerified = 38;

        /// <summary>
        /// The Email has yet to be verified.
        /// </summary>
        public const int EmailHasNotBeenVerified = 39;

        /// <summary>
        /// The given two-factor code was incorrect.
        /// </summary>
        public const int TwoFactorCodeIncorrect = 40;

        /// <summary>
        /// The user is not authorized against the server.
        /// </summary>
        public const int UnauthorizedUser = 41;

        /// <summary>
        /// The content in question is forbidden to the user.
        /// </summary>
        public const int ContentIsForbidden = 42;

        /// <summary>
        /// Indicates a non-descriptive general error related to auth.
        /// </summary>
        public const int GeneralAuthError = 43;

        /// <summary>
        /// Indicates a challenge by the authentication scheme.
        /// </summary>
        public const int AuthenticationChallenged = 44;
    }
}
