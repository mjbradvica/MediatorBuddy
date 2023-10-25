// <copyright file="MediatorBuddyValidationAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Class for easily adding an validation attribute for controllers.
    /// </summary>
    public class MediatorBuddyValidationAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyValidationAttribute"/> class.
        /// </summary>
        public MediatorBuddyValidationAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status400BadRequest)
        {
        }
    }
}
