// <copyright file="MediatorBuddy503ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 503 status code.
    /// </summary>
    public class MediatorBuddy503ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy503ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy503ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)
        {
        }
    }
}
