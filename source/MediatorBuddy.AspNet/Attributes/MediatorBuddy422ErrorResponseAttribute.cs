// <copyright file="MediatorBuddy422ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 422 status code.
    /// </summary>
    public class MediatorBuddy422ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy422ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy422ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)
        {
        }
    }
}
