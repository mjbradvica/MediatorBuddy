// <copyright file="MediatorBuddy505ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 505 status code.
    /// </summary>
    public class MediatorBuddy505ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy505ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy505ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status505HttpVersionNotsupported)
        {
        }
    }
}
