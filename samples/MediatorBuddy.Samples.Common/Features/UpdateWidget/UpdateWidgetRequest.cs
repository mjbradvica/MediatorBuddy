// <copyright file="UpdateWidgetRequest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Common.Features.UpdateWidget
{
    /// <summary>
    /// Sample widget request.
    /// </summary>
    public class UpdateWidgetRequest : IEnvelopeRequest<UpdateWidgetResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWidgetRequest"/> class.
        /// </summary>
        /// <param name="id">The id of the widget.</param>
        /// <param name="name">The new widget name.</param>
        [JsonConstructor]
        public UpdateWidgetRequest(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the widget id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the new widget name.
        /// </summary>
        [MinLength(3)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; }
    }
}
