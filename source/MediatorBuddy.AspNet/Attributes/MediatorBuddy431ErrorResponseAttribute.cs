// <copyright file="MediatorBuddy431ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 431 status code.
    /// </summary>
    public class MediatorBuddy431ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy431ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy431ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status431RequestHeaderFieldsTooLarge)
        {
        }
    }
}
