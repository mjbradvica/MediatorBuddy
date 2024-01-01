// <copyright file="MediatorBuddy414ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 414 status code.
    /// </summary>
    public class MediatorBuddy414ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy414ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy414ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status414UriTooLong)
        {
        }
    }
}
