// <copyright file="UpdateWeatherHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Api.UpdateWeather
{
    /// <summary>
    /// Sample handler class.
    /// </summary>
    public class UpdateWeatherHandler : IEnvelopeHandler<UpdateWeatherRequest, UpdateWeatherResponse>
    {
        /// <summary>
        /// Sample handler.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        public Task<IEnvelope<UpdateWeatherResponse>> Handle(UpdateWeatherRequest request, CancellationToken cancellationToken)
        {
            var response = Envelope<UpdateWeatherResponse>.Success(new UpdateWeatherResponse());

            return Task.FromResult(response);
        }
    }
}
