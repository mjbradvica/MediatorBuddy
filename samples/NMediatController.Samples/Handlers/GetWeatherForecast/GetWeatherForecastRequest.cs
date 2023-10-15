// <copyright file="GetWeatherForecastRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatR;

namespace NMediatController.Samples.Handlers.GetWeatherForecast
{
    /// <summary>
    /// Request for a weather forecast.
    /// </summary>
    public class GetWeatherForecastRequest : IRequest<Envelope<GetWeatherForecastResponse>>
    {
    }
}
