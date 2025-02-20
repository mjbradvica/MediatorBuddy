// <copyright file="MediatorBuddy424ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 424 status code.
    /// </summary>
    public class MediatorBuddy424ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy424ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy424ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status424FailedDependency)
        {
        }
    }
}
