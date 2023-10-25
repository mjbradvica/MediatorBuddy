// <copyright file="MediatorBuddyErrorAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Class for easily adding an error attribute for controllers.
    /// </summary>
    public class MediatorBuddyErrorAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyErrorAttribute"/> class.
        /// </summary>
        public MediatorBuddyErrorAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)
        {
        }
    }
}
