// <copyright file="CustomEnvelope.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Api.CustomFaults
{
    /// <summary>
    /// Custom faults.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class CustomEnvelope<TResponse>
    {
        /// <summary>
        /// Returns a not enough steam response.
        /// </summary>
        /// <returns>A <see cref="IEnvelope{TResponse}"/>.</returns>
        public static IEnvelope<TResponse> NotEnoughSteam()
        {
            return new Envelope<TResponse>(
                CustomApplicationStatus.NotEnoughSteam,
                "Not enough steam.",
                "You don't have enough steam to run that command.");
        }
    }
}
