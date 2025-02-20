// <copyright file="MediatorBuddy411ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 411 status code.
    /// </summary>
    public class MediatorBuddy411ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy411ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy411ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status411LengthRequired)
        {
        }
    }
}
