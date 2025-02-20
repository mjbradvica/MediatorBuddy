// <copyright file="MediatorBuddy400ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 400 status code.
    /// </summary>
    public class MediatorBuddy400ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy400ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy400ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status400BadRequest)
        {
        }
    }
}
