// <copyright file="MediatorBuddy403ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 403 status code.
    /// </summary>
    public class MediatorBuddy403ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy403ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy403ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status403Forbidden)
        {
        }
    }
}
