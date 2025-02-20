// <copyright file="CustomErrorTypes.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;

namespace MediatorBuddy.Samples.Api.CustomFaults
{
    /// <summary>
    /// Custom error types.
    /// </summary>
    public class CustomErrorTypes : ErrorTypes
    {
        /// <summary>
        /// Gets or sets the location for the not enough steam error.
        /// </summary>
        public Uri NotEnoughSteam { get; set; } = new Uri("Error/NotEnoughSteam", UriKind.Relative);
    }
}
