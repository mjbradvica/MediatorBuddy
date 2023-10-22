// <copyright file="GetWeatherHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

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
            return Task.FromResult(Envelope<GetWeatherResponse>.Failure(ApplicationStatus.UserNameAlreadyExists) as IEnvelope<GetWeatherResponse>);
        }
    }
}
