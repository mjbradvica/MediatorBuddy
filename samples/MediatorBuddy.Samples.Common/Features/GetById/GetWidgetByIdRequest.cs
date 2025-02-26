﻿// <copyright file="GetWidgetByIdRequest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Common.Features.GetById
{
    /// <summary>
    /// Sample get widget by id request.
    /// </summary>
    public class GetWidgetByIdRequest : IEnvelopeRequest<GetWidgetByIdResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWidgetByIdRequest"/> class.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        [JsonConstructor]
        public GetWidgetByIdRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the request id.
        /// </summary>
        public Guid Id { get; }
    }
}
