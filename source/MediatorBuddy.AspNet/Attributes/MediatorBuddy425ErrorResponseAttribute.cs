// <copyright file="MediatorBuddy425ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 425 status code.
    /// </summary>
    public class MediatorBuddy425ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy425ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy425ErrorResponseAttribute()
            : base(typeof(ErrorResponse), 425)
        {
        }
    }
}
