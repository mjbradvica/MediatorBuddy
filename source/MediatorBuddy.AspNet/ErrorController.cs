// <copyright file="ErrorController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// Standard error controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public abstract class ErrorController : ControllerBase
    {
        /// <summary>
        /// An explanation for the <see cref="ApplicationStatus.GeneralError"/>.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("GeneralError")]
        public virtual IActionResult GeneralError()
        {
            return Ok("A general error is most likely an un-classified error. The system was unable to determine what error to choose from. This is different than a 500 where the server experienced a fault and needs to physically recover.");
        }

        /// <summary>
        /// An explanation for the <see cref="ApplicationStatus.OperationCouldNotBeCompleted"/>.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("OperationCouldNotBeCompleted")]
        public virtual IActionResult OperationCouldNotBeCompleted()
        {
            return Ok("The operation could not be completed at this time. The operation may have on partially completed and faulted part way through. You may experience inconsistent results until the system is able to recover.");
        }

        /// <summary>
        /// An explanation for the <see cref="ApplicationStatus.EntityWasNotFound"/>.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("EntityWasNotFound")]
        public virtual IActionResult EntityWasNotFound()
        {
            return Ok("The entity was not found. This could mean it was deleted or moved since the last time it was accessed. You may have also provided an invalid identifier to find an entity.");
        }

        /// <summary>
        /// An explanation for the <see cref="ApplicationStatus.ConflictWithOtherResource"/>.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("ConflictWithOtherResource")]
        public virtual IActionResult ConflictWithOtherResource()
        {
            return Ok("A conflict occurred with an already existing resource in the system. This may be that both resource were attempting to access a different entity at the same time. A retry may be necessary.");
        }

        /// <summary>
        /// An explanation for the <see cref="ApplicationStatus.ValidationConstraintNotMet"/>.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("ValidationConstraintNotMet")]
        public virtual IActionResult ValidationConstraintNotMet()
        {
            return Ok();
        }
    }
}
