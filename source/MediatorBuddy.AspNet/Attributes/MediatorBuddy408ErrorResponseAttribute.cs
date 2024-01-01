// <copyright file="MediatorBuddy408ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 408 status code.
    /// </summary>
    public class MediatorBuddy408ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy408ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy408ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status408RequestTimeout)
        {
        }
    }
}