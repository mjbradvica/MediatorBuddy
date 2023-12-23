﻿// <copyright file="AddWidgetRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Api.Features.AddWidget
{
    /// <summary>
    /// Sample add widget request.
    /// </summary>
    public class AddWidgetRequest : IEnvelopeRequest<AddWidgetResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddWidgetRequest"/> class.
        /// </summary>
        /// <param name="name">The name of the new widget.</param>
        [JsonConstructor]
        public AddWidgetRequest(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the widget name.
        /// </summary>
        [MinLength(3)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; }
    }
}
