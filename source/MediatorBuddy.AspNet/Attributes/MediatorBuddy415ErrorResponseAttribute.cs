// <copyright file="MediatorBuddy415ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 415 status code.
    /// </summary>
    public class MediatorBuddy415ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy415ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy415ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status415UnsupportedMediaType)
        {
        }
    }
}
