// <copyright file="MediatorBuddy423ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 423 status code.
    /// </summary>
    public class MediatorBuddy423ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy423ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy423ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status423Locked)
        {
        }
    }
}
