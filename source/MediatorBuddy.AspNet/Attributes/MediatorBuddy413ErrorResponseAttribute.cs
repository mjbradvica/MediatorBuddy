// <copyright file="MediatorBuddy413ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 4013 status code.
    /// </summary>
    public class MediatorBuddy413ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy413ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy413ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status413PayloadTooLarge)
        {
        }
    }
}
