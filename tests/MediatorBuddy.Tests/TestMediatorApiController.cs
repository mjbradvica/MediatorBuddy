// <copyright file="TestMediatorApiController.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
        public TestMediatorApiController(IMediator mediator, Func<ApiErrorWrapper, IActionResult?>? extraOptions = null)
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

        /// <summary>
        /// Ok object response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> HandleOkObject()
        {
            return await ExecuteOkObject(TestObjectRequest.Valid(), CancellationToken.None);
        }

        /// <summary>
        /// Accepted location object response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> HandleAcceptedLocation()
        {
            return await ExecuteAcceptedObject(TestObjectRequest.Valid(), _ => new Uri("https://www.mySite.com"), CancellationToken.None);
        }

        /// <summary>
        /// Accepted location object response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> HandleAccepted()
        {
            return await ExecuteAcceptedObject(TestObjectRequest.Valid(), CancellationToken.None);
        }

        /// <summary>
        /// Created location object response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> HandleCreatedLocation()
        {
            return await ExecuteCreatedObject(TestObjectRequest.Valid(), _ => new Uri("https://www.mySite.com"), CancellationToken.None);
        }

        /// <summary>
        /// Created location object response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> HandleCreated()
        {
            return await ExecuteCreatedObject(TestObjectRequest.Valid(), CancellationToken.None);
        }

        /// <summary>
        /// No Content response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> HandleNoContent()
        {
            return await ExecuteNoContent(new TestUnitRequest(), CancellationToken.None);
        }
    }
}
