// <copyright file="MediatorBuddy502ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 502 status code.
    /// </summary>
    public class MediatorBuddy502ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy502ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy502ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status502BadGateway)
        {
        }
    }
}
