// <copyright file="MediatorBuddy508ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 508 status code.
    /// </summary>
    public class MediatorBuddy508ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy508ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy508ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status508LoopDetected)
        {
        }
    }
}
