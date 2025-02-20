// <copyright file="MediatorBuddy418ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 418 status code.
    /// </summary>
    public class MediatorBuddy418ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy418ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy418ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status418ImATeapot)
        {
        }
    }
}
