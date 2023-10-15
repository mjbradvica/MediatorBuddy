﻿using System.Threading.Tasks;
using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// A test controller used for unit testing.
    /// </summary>
    public class TestMediatApiController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMediatApiController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the Mediator object.</param>
        public TestMediatApiController(IMediator mediator)
            : base(mediator)
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