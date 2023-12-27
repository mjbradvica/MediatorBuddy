// <copyright file="MediatorBuddy428ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 428 status code.
    /// </summary>
    public class MediatorBuddy428ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy428ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy428ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status428PreconditionRequired)
        {
        }
    }
}
