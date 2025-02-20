// <copyright file="MediatorBuddy504ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 504 status code.
    /// </summary>
    public class MediatorBuddy504ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy504ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy504ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status504GatewayTimeout)
        {
        }
    }
}
