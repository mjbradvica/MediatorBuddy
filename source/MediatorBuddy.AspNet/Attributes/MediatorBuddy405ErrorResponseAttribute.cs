// <copyright file="MediatorBuddy405ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// <summary>
    /// Attribute for a <see cref="ErrorResponse"/> with a 405 status code.
    /// </summary>
public class MediatorBuddy405ErrorResponseAttribute : ProducesResponseTypeAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatorBuddy405ErrorResponseAttribute"/> class.
    /// </summary>
    public MediatorBuddy405ErrorResponseAttribute()
        : base(typeof(ErrorResponse), StatusCodes.Status405MethodNotAllowed)
    {
    }
}