// <copyright file="MediatorBuddy412ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 412 status code.
    /// </summary>
    public class MediatorBuddy412ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy412ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy412ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status412PreconditionFailed)
        {
        }
    }
}
