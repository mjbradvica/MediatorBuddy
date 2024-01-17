// <copyright file="TestMediatorPage.cs" company="Michael Bradvica LLC">
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
    /// Test page controller.
    /// </summary>
    internal class TestMediatorPage : MediatorBuddyPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMediatorPage"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="extraOptions">Func for error options.</param>
        public TestMediatorPage(IMediator mediator, Func<RazorErrorWrapper, IActionResult?>? extraOptions = null)
            : base(mediator, extraOptions)
        {
            ViewModel = new TestResponse();
        }

        /// <summary>
        /// Gets or sets the test view model.
        /// </summary>
        [BindProperty]
        public TestResponse ViewModel { get; set; }

        /// <summary>
        /// A test action used for controller testing.
        /// </summary>
        /// <param name="request">A test request object.</param>
        /// <returns>An IActionResult from the controller operation.</returns>
        public async Task<IActionResult> TestEndpoint(TestObjectRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.RedirectToPageResponse<TestResponse>(_ => (null, null, null)));
        }

        /// <summary>
        /// A test action used for controller testing.
        /// </summary>
        /// <param name="request">A test request object.</param>
        /// <returns>An IActionResult from the controller operation.</returns>
        public async Task<IActionResult> TestActionEndpoint(TestObjectRequest request)
        {
            return await ExecuteRequest(request, response => ViewModel = response);
        }
    }
}
