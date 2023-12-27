// <copyright file="CustomFaultHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatR;

namespace MediatorBuddy.Samples.Api.CustomFaults
{
    /// <summary>
    /// Custom fault handler.
    /// </summary>
    public class CustomFaultHandler : IEnvelopeHandler<CustomFaultRequest>
    {
        /// <summary>
        /// Custom fault method.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public Task<IEnvelope<Unit>> Handle(CustomFaultRequest request, CancellationToken cancellationToken)
        {
            // Logic here.
            return Task.FromResult(CustomEnvelope<Unit>.NotEnoughSteam());
        }
    }
}
