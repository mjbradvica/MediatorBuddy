// <copyright file="MediatorBuddy500ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 500 status code.
    /// </summary>
    public class MediatorBuddy500ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy500ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy500ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)
        {
        }
    }
}
