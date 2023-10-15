// <copyright file="GetTimeRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NMediatController.Samples.Handlers.GetCurrentTime
{
    /// <summary>
    /// Gets the current time in UTC request.
    /// </summary>
    public class GetTimeRequest : IEnvelopeRequest<GetTimeResponse>
    {
    }
}
