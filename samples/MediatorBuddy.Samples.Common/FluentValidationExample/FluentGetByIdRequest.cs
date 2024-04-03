// <copyright file="FluentGetByIdRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Common.FluentValidationExample
{
    /// <summary>
    /// Sample fluent request.
    /// </summary>
    public class FluentGetByIdRequest : IEnvelopeRequest<FluentGetByIdResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentGetByIdRequest"/> class.
        /// </summary>
        /// <param name="id">The identifier for the request.</param>
        [JsonConstructor]
        public FluentGetByIdRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the request identifier.
        /// </summary>
        public Guid Id { get; }
    }
}
