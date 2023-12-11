// <copyright file="Envelope.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy
{
    /// <summary>
    /// A class to wrap response in.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    public class Envelope<TResponse> : IEnvelope<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="response">The response object.</param>
        public Envelope(TResponse response)
        {
            Response = response;
            Status = ApplicationStatus.Success;
            Title = string.Empty;
            Detail = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        public Envelope(int statusCode, string title, string detail)
        {
            Status = statusCode;
            Response = default!;
            Title = title;
            Detail = detail;
        }

        /// <inheritdoc/>
        public int Status { get; }

        /// <inheritdoc/>
        public string Title { get; }

        /// <inheritdoc/>
        public string Detail { get; }

        /// <inheritdoc/>
        public TResponse Response { get; }

        /// <summary>
        /// Factory function for success Envelope.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>A new response Envelope.</returns>
        public static Envelope<TResponse> Success(TResponse response)
        {
            return new Envelope<TResponse>(response);
        }

        /// <summary>
        /// Factory function for a failed Envelope.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static Envelope<TResponse> Failure(int statusCode, string title = "A failure occurred.", string detail = "No details are available for the failure.")
        {
            return new Envelope<TResponse>(statusCode, title, detail);
        }

        /// <summary>
        /// Function to return a general error of no real description.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> GeneralError(string title = "General error occurred.", string detail = "A non-description fault happened somewhere along the process.")
        {
            return new Envelope<TResponse>(ApplicationStatus.GeneralError, title, detail);
        }

        /// <summary>
        /// Function to return an operation could not be completed error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> OperationCouldNotBeCompleted(
            string title = "Operation could not be completed.",
            string detail = "The operation was unable to finish in its entirety.")
        {
            return new Envelope<TResponse>(ApplicationStatus.OperationCouldNotBeCompleted, title, detail);
        }

        /// <summary>
        /// Function to return an entity not found error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> EntityWasNotFound(
            string title = "The entity could not be found.",
            string detail = "The system was unable to find the requested entity with the given information.")
        {
            return new Envelope<TResponse>(ApplicationStatus.EntityWasNotFound, title, detail);
        }

        /// <summary>
        /// Function to return a conflict with other resource error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> ConflictWithOtherResource(
            string title = "A conflict exists with another resource.",
            string detail =
                "Another resource or entity already has conflict with another resource that prohibits this operation.")
        {
            return new Envelope<TResponse>(ApplicationStatus.ConflictWithOtherResource, title, detail);
        }

        /// <summary>
        /// Function to return a validation constraint not met error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> ValidationConstraintNotMet(
            string title = "A validation constraint was not met.",
            string detail =
                "An entity or request did not match the specified parameters and the operation could not continue.")
        {
            return new Envelope<TResponse>(ApplicationStatus.ValidationConstraintNotMet, title, detail);
        }

        /// <summary>
        /// Function to return a pre-condition constraint error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> PreConditionNotMet(
            string title = "A pre-condition was not met.",
            string detail = "A validation constraint before the operation could be started was not fulfilled.")
        {
            return new Envelope<TResponse>(ApplicationStatus.PreConditionNotMet, title, detail);
        }

        /// <summary>
        /// Function to return a post-condition constraint error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> PostConditionNotMet(
            string title = "A post-condition was not met.",
            string detail = "A validation constraint after the operation finished was not fulfilled.")
        {
            return new Envelope<TResponse>(ApplicationStatus.PostConditionNotMet, title, detail);
        }

        /// <summary>
        /// Function to return a user does not error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> UserDoesNotExist(
            string title = "User does not exist.",
            string detail = "The user given the current information could not be found.")
        {
            return new Envelope<TResponse>(ApplicationStatus.UserDoesNotExist, title, detail);
        }

        /// <summary>
        /// Function to return user could not be created error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> UserCouldNotBeCreated(
            string title = "User could not be created.",
            string detail = "A user could not be created given the current information.")
        {
            return new Envelope<TResponse>(ApplicationStatus.UserCouldNotBeCreated, title, detail);
        }

        /// <summary>
        /// Function to return UserName already exists error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> UserNameAlreadyExists(
            string title = "UserName already exists.",
            string detail = "That username is already in use and may not be duplicated.")
        {
            return new Envelope<TResponse>(ApplicationStatus.UserNameAlreadyExists, title, detail);
        }

        /// <summary>
        /// Function to return email is already used error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> EmailIsAlreadyUsed(
            string title = "Email is already used.",
            string detail = "The email given is already being used by an existing user.")
        {
            return new Envelope<TResponse>(ApplicationStatus.EmailIsAlreadyUsed, title, detail);
        }

        /// <summary>
        /// Function to return password is incorrect error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> PasswordIsIncorrect(
            string title = "Password is not correct.",
            string detail = "The password given is incorrect for the specified user.")
        {
            return new Envelope<TResponse>(ApplicationStatus.PasswordIsIncorrect, title, detail);
        }

        /// <summary>
        /// Function to return password does not meet requirements error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> PasswordDoesNotMeetRequirements(
            string title = "Password does not make requirements.",
            string detail = "The password does not have the correct number of strength modifiers.")
        {
            return new Envelope<TResponse>(ApplicationStatus.PasswordDoesNotMeetRequirements, title, detail);
        }

        /// <summary>
        /// Function to return too many recent attempts error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> TooManyRecentAttempts(
            string title = "Too many recent attempts.",
            string detail = "User has attempted too many login attempts recently.")
        {
            return new Envelope<TResponse>(ApplicationStatus.TooManyRecentAttempts, title, detail);
        }

        /// <summary>
        /// Function to return account is locked out error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> AccountIsLockedOut(
            string title = "Account is locked out.",
            string detail = "The account is currently locked out due to suspicious activity.")
        {
            return new Envelope<TResponse>(ApplicationStatus.AccountIsLockedOut, title, detail);
        }

        /// <summary>
        /// Function to return account has not been verified error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> AccountHasNotBeenVerified(
            string title = "Account has not been verified.",
            string detail = "The account has not been verified and has reduced capabilities.")
        {
            return new Envelope<TResponse>(ApplicationStatus.AccountHasNotBeenVerified, title, detail);
        }

        /// <summary>
        /// Function to return email has not been verified error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> EmailHasNotBeenVerified(
            string title = "Email has not been verified.",
            string detail = "The email has not been verified, reducing the account capabilities.")
        {
            return new Envelope<TResponse>(ApplicationStatus.EmailHasNotBeenVerified, title, detail);
        }

        /// <summary>
        /// Function to return two-factor code is incorrect error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> TwoFactorCodeIsIncorrect(
            string title = "Two factor code is incorrect.",
            string detail = "The two factor code did not match what was expected.")
        {
            return new Envelope<TResponse>(ApplicationStatus.TwoFactorCodeIncorrect, title, detail);
        }

        /// <summary>
        /// Function to return an unauthorized user error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> UnauthorizedUser(
            string title = "The current user in question is unauthorized.",
            string detail = "The user must first provide credentials before they may access specific content.")
        {
            return new Envelope<TResponse>(ApplicationStatus.UnauthorizedUser, title, detail);
        }

        /// <summary>
        /// Function to return a content is forbidden error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A new response Envelope.</returns>
        public static IEnvelope<TResponse> ContentIsForbidden(
            string title = "The content is forbidden.",
            string detail = "The current user does not have the proper credentials to access the content.")
        {
            return new Envelope<TResponse>(ApplicationStatus.ContentIsForbidden, title, detail);
        }
    }
}
