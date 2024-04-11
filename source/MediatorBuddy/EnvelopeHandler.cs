// <copyright file="EnvelopeHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatR;
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
        protected IEnvelope<TResponse> GeneralError(string title = "General error occurred.", string detail = "A non-description fault happened somewhere along the process.")
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
    }
}
