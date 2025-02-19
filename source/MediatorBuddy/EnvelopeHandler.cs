// <copyright file="EnvelopeHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace MediatorBuddy
{
    /// <summary>
    /// Base class for all envelope handlers.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public abstract class EnvelopeHandler<TRequest, TResponse> : IEnvelopeHandler<TRequest, TResponse>
        where TRequest : IEnvelopeRequest<TResponse>
    {
        /// <inheritdoc/>
        public abstract Task<IEnvelope<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Factory function for success Envelope.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> Success(TResponse response)
        {
            return Envelope<TResponse>.Success(response);
        }

        /// <summary>
        /// Factory function for a failed Envelope.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> Failure(int statusCode, string title = "A failure occurred.", string detail = "No details are available for the failure.")
        {
            return new Envelope<TResponse>(statusCode, title, detail);
        }

        /// <summary>
        /// Function to return a general error of no real description.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> GeneralError(
            string title = "General error occurred.",
            string detail = "A non-description fault happened somewhere along the process.")
        {
            return Envelope<TResponse>.GeneralError(title, detail);
        }

        /// <summary>
        /// Function to return an operation could not be completed error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> OperationCouldNotBeCompleted(
            string title = "Operation could not be completed.",
            string detail = "The operation was unable to finish in its entirety.")
        {
            return Envelope<TResponse>.OperationCouldNotBeCompleted(title, detail);
        }

        /// <summary>
        /// Function to return an entity not found error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> EntityWasNotFound(
            string title = "The entity could not be found.",
            string detail = "The system was unable to find the requested entity with the given information.")
        {
            return Envelope<TResponse>.EntityWasNotFound(title, detail);
        }

        /// <summary>
        /// Function to return a conflict with other resource error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> ConflictWithOtherResource(
            string title = "A conflict exists with another resource.",
            string detail = "Another resource or entity already has conflict with another resource that prohibits this operation.")
        {
            return Envelope<TResponse>.ConflictWithOtherResource(title, detail);
        }

        /// <summary>
        /// Function to return a validation constraint not met error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> ValidationConstraintNotMet(
            string title = "A validation constraint was not met.",
            string detail = "An entity or request did not match the specified parameters and the operation could not continue.")
        {
            return Envelope<TResponse>.ValidationConstraintNotMet(title, detail);
        }

        /// <summary>
        /// Function to return a pre-condition constraint error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> PreConditionNotMet(
            string title = "A pre-condition was not met.",
            string detail = "A validation constraint before the operation could be started was not fulfilled.")
        {
            return Envelope<TResponse>.PreConditionNotMet(title, detail);
        }

        /// <summary>
        /// Function to return a post-condition constraint error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> PostConditionNotMet(
            string title = "A post-condition was not met.",
            string detail = "A validation constraint after the operation finished was not fulfilled.")
        {
            return Envelope<TResponse>.PostConditionNotMet(title, detail);
        }

        /// <summary>
        /// Function to return a request could not be processed error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> CouldNotProcessRequest(
            string title = "Could not process request.",
            string detail = "The request could not be processed at this time.")
        {
            return Envelope<TResponse>.CouldNotProcessRequest(title, detail);
        }

        /// <summary>
        /// Function to return a user does not error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> UserDoesNotExist(
            string title = "User does not exist.",
            string detail = "The user given the current information could not be found.")
        {
            return Envelope<TResponse>.UserDoesNotExist(title, detail);
        }

        /// <summary>
        /// Function to return user could not be created error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> UserCouldNotBeCreated(
            string title = "User could not be created.",
            string detail = "A user could not be created given the current information.")
        {
            return Envelope<TResponse>.UserCouldNotBeCreated(title, detail);
        }

        /// <summary>
        /// Function to return UserName already exists error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> UsernameAlreadyExists(
            string title = "UserName already exists.",
            string detail = "That username is already in use and may not be duplicated.")
        {
            return Envelope<TResponse>.UsernameAlreadyExists(title, detail);
        }

        /// <summary>
        /// Function to return email is already used error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> EmailIsAlreadyUsed(
            string title = "Email is already used.",
            string detail = "The email given is already being used by an existing user.")
        {
            return Envelope<TResponse>.EmailIsAlreadyUsed(title, detail);
        }

        /// <summary>
        /// Function to return password is incorrect error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> PasswordIsIncorrect(
            string title = "Password is not correct.",
            string detail = "The password given is incorrect for the specified user.")
        {
            return Envelope<TResponse>.PasswordIsIncorrect(title, detail);
        }

        /// <summary>
        /// Function to return password does not meet requirements error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> PasswordDoesNotMeetRequirements(
            string title = "Password does not make requirements.",
            string detail = "The password does not have the correct number of strength modifiers.")
        {
            return Envelope<TResponse>.PasswordDoesNotMeetRequirements(title, detail);
        }

        /// <summary>
        /// Function to return too many recent attempts error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> TooManyRecentAttempts(
            string title = "Too many recent attempts.",
            string detail = "User has attempted too many login attempts recently.")
        {
            return Envelope<TResponse>.TooManyRecentAttempts(title, detail);
        }

        /// <summary>
        /// Function to return account is locked out error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> AccountIsLockedOut(
            string title = "Account is locked out.",
            string detail = "The account is currently locked out due to suspicious activity.")
        {
            return Envelope<TResponse>.AccountIsLockedOut(title, detail);
        }

        /// <summary>
        /// Function to return account has not been verified error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> AccountHasNotBeenVerified(
            string title = "Account has not been verified.",
            string detail = "The account has not been verified and has reduced capabilities.")
        {
            return Envelope<TResponse>.AccountHasNotBeenVerified(title, detail);
        }

        /// <summary>
        /// Function to return email has not been verified error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> EmailHasNotBeenVerified(
            string title = "Email has not been verified.",
            string detail = "The email has not been verified, reducing the account capabilities.")
        {
            return Envelope<TResponse>.EmailHasNotBeenVerified(title, detail);
        }

        /// <summary>
        /// Function to return two-factor code is incorrect error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> TwoFactorCodeIsIncorrect(
            string title = "Two factor code is incorrect.",
            string detail = "The two factor code did not match what was expected.")
        {
            return Envelope<TResponse>.TwoFactorCodeIsIncorrect(title, detail);
        }

        /// <summary>
        /// Function to return an unauthorized user error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> UnauthorizedUser(
            string title = "The current user in question is unauthorized.",
            string detail = "The user must first provide credentials before they may access specific content.")
        {
            return Envelope<TResponse>.UnauthorizedUser(title, detail);
        }

        /// <summary>
        /// Function to return a content is forbidden error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> ContentIsForbidden(
            string title = "The content is forbidden.",
            string detail = "The current user does not have the proper credentials to access the content.")
        {
            return Envelope<TResponse>.ContentIsForbidden(title, detail);
        }

        /// <summary>
        /// Function to return a general auth error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> GeneralAuthError(
            string title = "General auth error.",
            string detail = "A non-descriptive error related to the auth process occurred.")
        {
            return Envelope<TResponse>.GeneralAuthError(title, detail);
        }

        /// <summary>
        /// Function to return an authentication challenge.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<TResponse> AuthenticationChallenged(
            string title = "The authentication scheme was challenged.",
            string detail = "The authentication is being questioned. The server is unable to verify the identity of the user; please verify the user.")
        {
            return Envelope<TResponse>.AuthenticationChallenged(title, detail);
        }
    }
}
