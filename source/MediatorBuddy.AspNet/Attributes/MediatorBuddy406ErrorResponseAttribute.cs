// <copyright file="MediatorBuddy406ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 406 status code.
    /// </summary>
    public class MediatorBuddy406ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy406ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy406ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status406NotAcceptable)
        {
        }
    }
}