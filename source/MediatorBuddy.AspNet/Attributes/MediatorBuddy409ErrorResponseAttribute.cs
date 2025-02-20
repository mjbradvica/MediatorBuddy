// <copyright file="MediatorBuddy409ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 409 status code.
    /// </summary>
    public class MediatorBuddy409ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy409ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy409ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status409Conflict)
        {
        }
    }
}
