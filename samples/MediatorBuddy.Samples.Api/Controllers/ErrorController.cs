﻿// <copyright file="ErrorController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.Controllers
{
    /// <summary>
    /// Override for errors.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : BaseErrorController
    {
    }
}
