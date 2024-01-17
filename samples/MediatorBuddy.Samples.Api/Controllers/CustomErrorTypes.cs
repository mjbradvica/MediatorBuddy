// <copyright file="CustomErrorTypes.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;

namespace MediatorBuddy.Samples.Api.Controllers
{
    /// <summary>
    /// Custom error types class.
    /// </summary>
    public class CustomErrorTypes : ErrorTypes
    {
        /// <summary>
        /// Gets or sets the not enough steam uri.
        /// </summary>
        public Uri NotEnoughSteam { get; set; } = new Uri("Error/NotEnoughSteam", UriKind.Relative);
    }
}
