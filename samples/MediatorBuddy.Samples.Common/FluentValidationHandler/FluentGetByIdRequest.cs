// <copyright file="FluentGetByIdRequest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Common.FluentValidationHandler
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
