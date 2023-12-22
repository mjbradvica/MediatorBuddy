// <copyright file="GetWeatherHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.SignalR;

namespace MediatorBuddy.Samples.Api.GetWeather
{
    /// <summary>
    /// Sample handler.
    /// </summary>
    public class GetWeatherHandler : IEnvelopeHandler<GetWeatherRequest, GetWeatherResponse>
    {
        /// <summary>
        /// Sample handler method.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Token.</param>
        /// <returns>Envelope response.</returns>
        public Task<IEnvelope<GetWeatherResponse>> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
        {
            var weather = new List<string> { "rainy", "windy", "calm" };

            var random = new Random();

            var data = weather[random.Next(0, 2)];

            if (data == null)
            {
                return Task.FromResult(Envelope<GetWeatherResponse>.EntityWasNotFound());
            }

            return Task.FromResult(Envelope<GetWeatherResponse>.Success(new GetWeatherResponse { Value = data }));
        }
    }
}
