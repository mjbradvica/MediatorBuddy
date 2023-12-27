// <copyright file="MediatorBuddy402ErrorResponseAttribute.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Attribute for a <see cref="ErrorResponse"/> with a 401 status code.
/// </summary>
public class MediatorBuddy402ErrorResponseAttribute : ProducesResponseTypeAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatorBuddy402ErrorResponseAttribute"/> class.
    /// </summary>
    public MediatorBuddy402ErrorResponseAttribute()
        : base(typeof(ErrorResponse), StatusCodes.Status402PaymentRequired)
    {
    }
}