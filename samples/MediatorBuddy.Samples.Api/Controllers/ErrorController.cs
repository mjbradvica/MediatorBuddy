// <copyright file="ErrorController.cs" company="Michael Bradvica LLC">
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
        /// <summary>
        /// Custom fault explanation.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("NotEnoughSteam")]
        public IActionResult NotEnoughSteam()
        {
            return Ok("You don't have enough steam to be a tea pot!");
        }

        /// <summary>
        /// Overridden error message for user could not be created.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="string"/>.</returns>
        public override IActionResult UserCouldNotBeCreated()
        {
            return Ok("A user could not be created possibly due to the following errors...");
        }
    }
}
