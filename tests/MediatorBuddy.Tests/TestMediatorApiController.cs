// <copyright file="TestMediatorApiController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// A test controller used for unit testing.
    /// </summary>
    public class TestMediatorApiController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMediatorApiController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the Mediator object.</param>
        /// <param name="extraOptions">Extra response options.</param>
        public TestMediatorApiController(IMediator mediator, Func<int, IActionResult>? extraOptions = null)
            : base(mediator, null, extraOptions)
        {
        }

        /// <summary>
        /// A test action used for controller testing.
        /// </summary>
        /// <param name="request">A test request object.</param>
        /// <returns>An IActionResult from the controller operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Handle(TestObjectRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.OkObjectResponse<TestResponse>());
        }
    }
}
