// <copyright file="MediatorBuddy511ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 511 status code.
    /// </summary>
    public class MediatorBuddy511ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy511ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy511ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status511NetworkAuthenticationRequired)
        {
        }
    }
}
