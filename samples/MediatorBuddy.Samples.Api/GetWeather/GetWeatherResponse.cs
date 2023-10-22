// <copyright file="GetWeatherResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Api.GetWeather
{
    /// <summary>
    /// Sample response.
    /// </summary>
    public class GetWeatherResponse
    {
        /// <summary>
        /// Gets the weather value.
        /// </summary>
        public string Value { get; } = "Windy, rainy, and hot.";
    }
}
