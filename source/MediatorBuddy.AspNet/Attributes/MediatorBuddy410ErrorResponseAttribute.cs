// <copyright file="MediatorBuddy410ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 410 status code.
    /// </summary>
    public class MediatorBuddy410ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy410ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy410ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status410Gone)
        {
        }
    }
}