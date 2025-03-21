﻿// <copyright file="MediatorBuddy421ErrorResponseAttribute.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Attributes
{
    /// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 421 status code.
    /// </summary>
    public class MediatorBuddy421ErrorResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddy421ErrorResponseAttribute"/> class.
        /// </summary>
        public MediatorBuddy421ErrorResponseAttribute()
            : base(typeof(ErrorResponse), StatusCodes.Status421MisdirectedRequest)
        {
        }
    }
}
