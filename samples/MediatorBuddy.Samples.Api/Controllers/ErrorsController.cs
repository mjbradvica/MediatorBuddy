// <copyright file="ErrorsController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.Controllers
{
    /// <summary>
    /// Controller for errors.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ErrorsController : ControllerBase
    {
        /// <summary>
        /// Returns general errors.
        /// </summary>
        /// <returns>A list of error types.</returns>
        [HttpGet("general")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public IActionResult GeneralErrors()
        {
            var errors = new List<string>();

            return Ok(errors);
        }
    }
}
