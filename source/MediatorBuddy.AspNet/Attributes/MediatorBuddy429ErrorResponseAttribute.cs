// <copyright file="MediatorBuddy429ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 429 status code.
    /// </summary>
    public class MediatorBuddy429ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy429ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy429ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status429TooManyRequests)
        {
        }
    }
}
