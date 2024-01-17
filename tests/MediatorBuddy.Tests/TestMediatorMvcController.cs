// <copyright file="TestMediatorMvcController.cs" company="Michael Bradvica LLC">
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
    /// Test mvc controller.
    /// </summary>
    internal class TestMediatorMvcController : MediatorBuddyMvc
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMediatorMvcController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="extraOptions">Error result func.</param>
        public TestMediatorMvcController(IMediator mediator, Func<RazorErrorWrapper, IActionResult?>? extraOptions = null)
            : base(mediator, extraOptions)
        {
        }

        /// <summary>
        /// A test action used for controller testing.
        /// </summary>
        /// <param name="request">A test request object.</param>
        /// <returns>An IActionResult from the controller operation.</returns>
        public async Task<IActionResult> TestEndpoint(TestObjectRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.RedirectToActionResponse<TestResponse>(_ => ("MyAction", null, null)));
        }

        /// <summary>
        /// A test action used for controller testing.
        /// </summary>
        /// <param name="request">A test request object.</param>
        /// <returns>An IActionResult from the controller operation.</returns>
        public async Task<IActionResult> TestRazorDataEndpoint(TestObjectRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.ViewResponse<TestResponse>());
        }
    }
}
