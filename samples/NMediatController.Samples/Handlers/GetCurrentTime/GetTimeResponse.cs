// <copyright file="GetTimeResponse.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NMediatController.Samples.Handlers.GetCurrentTime
{
    /// <summary>
    /// Response object for getting the current time.
    /// </summary>
    public class GetTimeResponse
    {
        /// <summary>
        /// Gets a value indicating the current time.
        /// </summary>
        public DateTime TimeStamp { get; } = DateTime.UtcNow;
    }
}
