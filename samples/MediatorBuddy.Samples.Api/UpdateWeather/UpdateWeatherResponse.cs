// <copyright file="UpdateWeatherResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Api.UpdateWeather
{
    /// <summary>
    /// Sample response.
    /// </summary>
    public class UpdateWeatherResponse
    {
        /// <summary>
        /// Gets the Id for the response.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
    }
}
