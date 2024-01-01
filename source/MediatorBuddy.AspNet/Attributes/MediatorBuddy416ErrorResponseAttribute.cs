// <copyright file="MediatorBuddy416ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 416 status code.
    /// </summary>
    public class MediatorBuddy416ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy416ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy416ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status416RangeNotSatisfiable)
        {
        }
    }
}
