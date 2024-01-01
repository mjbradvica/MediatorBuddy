// <copyright file="CustomFaultController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.CustomFaults
{
    /// <summary>
    /// Sample custom fault controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomFaultController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFaultController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public CustomFaultController(IMediator mediator)
            : base(mediator, new CustomErrorTypes(), CustomErrorResolver.ResolveFaults)
        {
        }

        /// <summary>
        /// Custom fault endpoint.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status418ImATeapot)]
        public async Task<IActionResult> MyCustomRequest()
        {
            return await ExecuteRequest(new CustomFaultRequest(), ResponseOptions.OkEmpty<Unit>());
        }
    }
}
