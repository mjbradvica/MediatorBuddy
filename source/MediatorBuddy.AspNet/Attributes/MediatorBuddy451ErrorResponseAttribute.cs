// <copyright file="MediatorBuddy451ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 451 status code.
    /// </summary>
    public class MediatorBuddy451ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy451ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy451ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status451UnavailableForLegalReasons)
        {
        }
    }
}
