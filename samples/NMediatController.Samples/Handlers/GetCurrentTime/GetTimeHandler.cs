// <copyright file="GetTimeHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NMediatController.Samples.Handlers.GetCurrentTime
{
    /// <summary>
    /// Handles a <see cref="GetTimeRequest"/>.
    /// </summary>
    public class GetTimeHandler : IEnvelopeHandler<GetTimeRequest, GetTimeResponse>
    {
        /// <summary>
        /// Handles a <see cref="GetTimeRequest"/>.
        /// </summary>
        /// <param name="request">A <see cref="GetTimeRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A Task of <see cref="IEnvelope{TResponse}"/>.</returns>
        public Task<IEnvelope<GetTimeResponse>> Handle(GetTimeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Envelope<GetTimeResponse>.Success(new GetTimeResponse()) as IEnvelope<GetTimeResponse>);
        }
    }
}
