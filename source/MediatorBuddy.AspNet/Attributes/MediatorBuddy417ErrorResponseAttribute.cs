// <copyright file="MediatorBuddy417ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 417 status code.
    /// </summary>
    public class MediatorBuddy417ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy417ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy417ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status417ExpectationFailed)
        {
        }
    }
}
