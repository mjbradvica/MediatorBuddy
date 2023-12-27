// <copyright file="MediatorBuddy406ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Attribute for a <see cref="ErrorResponse"/> with a 406 status code.
/// </summary>
public class MediatorBuddy406ErrorResponseAttribute : ProducesResponseTypeAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatorBuddy406ErrorResponseAttribute"/> class.
    /// </summary>
    public MediatorBuddy406ErrorResponseAttribute()
        : base(typeof(ErrorResponse), StatusCodes.Status406NotAcceptable)
    {
    }
}