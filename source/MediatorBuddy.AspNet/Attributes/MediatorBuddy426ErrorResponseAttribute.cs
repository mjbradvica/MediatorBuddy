// <copyright file="MediatorBuddy426ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 426 status code.
    /// </summary>
    public class MediatorBuddy426ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy426ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy426ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status426UpgradeRequired)
        {
        }
    }
}
