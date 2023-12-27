// <copyright file="MediatorBuddy510ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 510 status code.
    /// </summary>
    public class MediatorBuddy510ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy510ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy510ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status510NotExtended)
        {
        }
    }
}
