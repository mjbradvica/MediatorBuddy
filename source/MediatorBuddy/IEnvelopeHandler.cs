// <copyright file="IEnvelopeHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatR;

namespace MediatorBuddy
{
    /// <summary>
    /// An EnvelopeHandler that will return an Envelope response.
    /// </summary>
    /// <typeparam name="TRequest">The request object for the handler.</typeparam>
    /// <typeparam name="TResponse">The response object for the handler.</typeparam>
    public interface IEnvelopeHandler<in TRequest, TResponse> : IRequestHandler<TRequest, IEnvelope<TResponse>>
        where TRequest : IEnvelopeRequest<TResponse>
    {
    }

    /// <summary>
    /// An EnvelopeHandler that will return an Envelope response.
    /// </summary>
    /// <typeparam name="TRequest">The request object for the handler.</typeparam>
    public interface IEnvelopeHandler<in TRequest> : IRequestHandler<TRequest, IEnvelope<Unit>>
        where TRequest : IEnvelopeRequest
    {
    }
}
