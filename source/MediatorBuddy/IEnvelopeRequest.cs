// <copyright file="IEnvelopeRequest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatR;

namespace MediatorBuddy
{
    /// <summary>
    /// An EnvelopeRequest that returns a Envelope response..
    /// </summary>
    /// <typeparam name="TResponse">The Response type of the request.</typeparam>
    public interface IEnvelopeRequest<out TResponse> : IRequest<IEnvelope<TResponse>>
    {
    }

    /// <summary>
    /// An EnvelopeRequest that returns a Unit or void.
    /// </summary>
    public interface IEnvelopeRequest : IRequest<IEnvelope<Unit>>
    {
    }
}
