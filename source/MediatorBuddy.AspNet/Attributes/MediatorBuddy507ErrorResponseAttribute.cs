// <copyright file="MediatorBuddy507ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 507 status code.
    /// </summary>
    public class MediatorBuddy507ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy507ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy507ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status507InsufficientStorage)
        {
        }
    }
}
