﻿// <copyright file="DeleteWidgetRequest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Common.Features.DeleteWidget
{
    /// <summary>
    /// Sample delete widget request.
    /// </summary>
    public class DeleteWidgetRequest : IEnvelopeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWidgetRequest"/> class.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        [JsonConstructor]
        public DeleteWidgetRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        public Guid Id { get; }
    }
}
