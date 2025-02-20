// <copyright file="MediatorBuddy407ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 401 status code.
    /// </summary>
    public class MediatorBuddy407ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy407ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy407ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status407ProxyAuthenticationRequired)
        {
        }
    }
}