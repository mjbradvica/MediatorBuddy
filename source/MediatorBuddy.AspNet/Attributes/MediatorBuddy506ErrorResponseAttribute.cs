// <copyright file="MediatorBuddy506ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 506 status code.
    /// </summary>
    public class MediatorBuddy506ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy506ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy506ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status506VariantAlsoNegotiates)
        {
        }
    }
}
