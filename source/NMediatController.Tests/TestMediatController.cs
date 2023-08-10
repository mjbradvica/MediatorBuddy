﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NMediatController.ASPNET;

namespace NMediatController.Tests
{
    /// <summary>
    /// A test controller used for unit testing.
    /// </summary>
    public class TestMediatController : BaseMediatController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMediatController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the Mediator object.</param>
        public TestMediatController(IMediator mediator)
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
            return await ExecuteRequest(request, ResponseOptions.OkObjectResponse());
        }
    }
}
