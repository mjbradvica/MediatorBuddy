// <copyright file="MediatorBuddy501ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 501 status code.
    /// </summary>
    public class MediatorBuddy501ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy501ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy501ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status501NotImplemented)
        {
        }
    }
}
