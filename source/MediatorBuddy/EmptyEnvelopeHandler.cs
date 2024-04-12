// <copyright file="EmptyEnvelopeHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatorBuddy
{
    /// <summary>
    /// Base class for Handlers that do not return a response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    public abstract class EnvelopeHandler<TRequest> : IEnvelopeHandler<TRequest>
        where TRequest : IEnvelopeRequest
    {
        /// <inheritdoc/>
        public abstract Task<IEnvelope<Unit>> Handle(TRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Factory function for a success Envelope that returns nothing.
        /// </summary>
        /// <returns>A <see cref="IEnvelope{TResponse}"/> of type <see cref="Unit"/>.</returns>
        protected IEnvelope<Unit> Success()
        {
            return Envelope<Unit>.Success();
        }

        /// <summary>
        /// Factory function for a failed Envelope.
        /// </summary>
        /// <param name="statusCode">The status code of the failure.</param>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> Failure(int statusCode, string title = "A failure occurred.", string detail = "No details are available for the failure.")
        {
            return new Envelope<Unit>(statusCode, title, detail);
        }

        /// <summary>
        /// Function to return a general error of no real description.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> GeneralError(
            string title = "General error occurred.",
            string detail = "A non-description fault happened somewhere along the process.")
        {
            return Envelope<Unit>.GeneralError(title, detail);
        }

        /// <summary>
        /// Function to return an operation could not be completed error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> OperationCouldNotBeCompleted(
            string title = "Operation could not be completed.",
            string detail = "The operation was unable to finish in its entirety.")
        {
            return Envelope<Unit>.OperationCouldNotBeCompleted(title, detail);
        }

        /// <summary>
        /// Function to return an entity not found error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> EntityWasNotFound(
            string title = "The entity could not be found.",
            string detail = "The system was unable to find the requested entity with the given information.")
        {
            return Envelope<Unit>.EntityWasNotFound(title, detail);
        }

        /// <summary>
        /// Function to return a conflict with other resource error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> ConflictWithOtherResource(
            string title = "A conflict exists with another resource.",
            string detail = "Another resource or entity already has conflict with another resource that prohibits this operation.")
        {
            return Envelope<Unit>.ConflictWithOtherResource(title, detail);
        }

        /// <summary>
        /// Function to return a validation constraint not met error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> ValidationConstraintNotMet(
            string title = "A validation constraint was not met.",
            string detail = "An entity or request did not match the specified parameters and the operation could not continue.")
        {
            return Envelope<Unit>.ValidationConstraintNotMet(title, detail);
        }

        /// <summary>
        /// Function to return a pre-condition constraint error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> PreConditionNotMet(
            string title = "A pre-condition was not met.",
            string detail = "A validation constraint before the operation could be started was not fulfilled.")
        {
            return Envelope<Unit>.PreConditionNotMet(title, detail);
        }

        /// <summary>
        /// Function to return a post-condition constraint error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> PostConditionNotMet(
            string title = "A post-condition was not met.",
            string detail = "A validation constraint after the operation finished was not fulfilled.")
        {
            return Envelope<Unit>.PostConditionNotMet(title, detail);
        }

        /// <summary>
        /// Function to return a request could not be processed error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> CouldNotProcessRequest(
            string title = "Could not process request.",
            string detail = "The request could not be processed at this time.")
        {
            return Envelope<Unit>.CouldNotProcessRequest(title, detail);
        }

        /// <summary>
        /// Function to return a user does not error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> UserDoesNotExist(
            string title = "User does not exist.",
            string detail = "The user given the current information could not be found.")
        {
            return Envelope<Unit>.UserDoesNotExist(title, detail);
        }

        /// <summary>
        /// Function to return user could not be created error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> UserCouldNotBeCreated(
            string title = "User could not be created.",
            string detail = "A user could not be created given the current information.")
        {
            return Envelope<Unit>.UserCouldNotBeCreated(title, detail);
        }

        /// <summary>
        /// Function to return UserName already exists error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> UsernameAlreadyExists(
            string title = "UserName already exists.",
            string detail = "That username is already in use and may not be duplicated.")
        {
            return Envelope<Unit>.UsernameAlreadyExists(title, detail);
        }

        /// <summary>
        /// Function to return email is already used error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> EmailIsAlreadyUsed(
            string title = "Email is already used.",
            string detail = "The email given is already being used by an existing user.")
        {
            return Envelope<Unit>.EmailIsAlreadyUsed(title, detail);
        }

        /// <summary>
        /// Function to return password is incorrect error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> PasswordIsIncorrect(
            string title = "Password is not correct.",
            string detail = "The password given is incorrect for the specified user.")
        {
            return Envelope<Unit>.PasswordIsIncorrect(title, detail);
        }

        /// <summary>
        /// Function to return password does not meet requirements error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> PasswordDoesNotMeetRequirements(
            string title = "Password does not make requirements.",
            string detail = "The password does not have the correct number of strength modifiers.")
        {
            return Envelope<Unit>.PasswordDoesNotMeetRequirements(title, detail);
        }

        /// <summary>
        /// Function to return too many recent attempts error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> TooManyRecentAttempts(
            string title = "Too many recent attempts.",
            string detail = "User has attempted too many login attempts recently.")
        {
            return Envelope<Unit>.TooManyRecentAttempts(title, detail);
        }

        /// <summary>
        /// Function to return account is locked out error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> AccountIsLockedOut(
            string title = "Account is locked out.",
            string detail = "The account is currently locked out due to suspicious activity.")
        {
            return Envelope<Unit>.AccountIsLockedOut(title, detail);
        }

        /// <summary>
        /// Function to return account has not been verified error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> AccountHasNotBeenVerified(
            string title = "Account has not been verified.",
            string detail = "The account has not been verified and has reduced capabilities.")
        {
            return Envelope<Unit>.AccountHasNotBeenVerified(title, detail);
        }

        /// <summary>
        /// Function to return email has not been verified error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> EmailHasNotBeenVerified(
            string title = "Email has not been verified.",
            string detail = "The email has not been verified, reducing the account capabilities.")
        {
            return Envelope<Unit>.EmailHasNotBeenVerified(title, detail);
        }

        /// <summary>
        /// Function to return two-factor code is incorrect error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> TwoFactorCodeIsIncorrect(
            string title = "Two factor code is incorrect.",
            string detail = "The two factor code did not match what was expected.")
        {
            return Envelope<Unit>.TwoFactorCodeIsIncorrect(title, detail);
        }

        /// <summary>
        /// Function to return an unauthorized user error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> UnauthorizedUser(
            string title = "The current user in question is unauthorized.",
            string detail = "The user must first provide credentials before they may access specific content.")
        {
            return Envelope<Unit>.UnauthorizedUser(title, detail);
        }

        /// <summary>
        /// Function to return a content is forbidden error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> ContentIsForbidden(
            string title = "The content is forbidden.",
            string detail = "The current user does not have the proper credentials to access the content.")
        {
            return Envelope<Unit>.ContentIsForbidden(title, detail);
        }

        /// <summary>
        /// Function to return a general auth error.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> GeneralAuthError(
            string title = "General auth error.",
            string detail = "A non-descriptive error related to the auth process occurred.")
        {
            return Envelope<Unit>.GeneralAuthError(title, detail);
        }

        /// <summary>
        /// Function to return an authentication challenge.
        /// </summary>
        /// <param name="title">The title of the failure.</param>
        /// <param name="detail">The detail of the failure.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        protected IEnvelope<Unit> AuthenticationChallenged(
            string title = "The authentication scheme was challenged.",
            string detail = "The authentication is being questioned. The server is unable to verify the identity of the user; please verify the user.")
        {
            return Envelope<Unit>.AuthenticationChallenged(title, detail);
        }
    }
}
