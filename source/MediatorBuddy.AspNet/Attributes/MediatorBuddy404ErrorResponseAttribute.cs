// <copyright file="MediatorBuddy404ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 404 status code.
    /// </summary>
    public class MediatorBuddy404ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy404ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy404ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status404NotFound)
        {
        }
    }
}
