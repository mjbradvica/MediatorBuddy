// <copyright file="MediatorBuddyStandardPageTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests for the base page.
    /// </summary>
    [TestClass]
    public class MediatorBuddyStandardPageTests
    {
        private readonly TestPage _testPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyStandardPageTests"/> class.
        /// </summary>
        public MediatorBuddyStandardPageTests()
        {
            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.Success(new TestResponse { Value = "value" }));

            mediator.Setup(x => x.Send(It.IsAny<UnitRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<Unit>.Success());

            _testPage = new TestPage(mediator.Object);
        }

        /// <summary>
        /// Ensures the execute query method is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteQuery_Empty_IsCorrect()
        {
            await _testPage.Query(TestObjectRequest.Valid());

            Assert.AreEqual("value", _testPage.ViewModel.Value);
        }

        /// <summary>
        /// Ensures the execute query method is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteQuery_MappingFunc_IsCorrect()
        {
            await _testPage.Query(TestObjectRequest.Valid(), response => _testPage.ViewModel = response);

            Assert.AreEqual("value", _testPage.ViewModel.Value);
        }

        /// <summary>
        /// Ensures the execute command method is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteCommand_PageName_IsCorrect()
        {
            var result = await _testPage.Command(new UnitRequest(), "myPage");

            var asResult = result as RedirectToPageResult;

            Assert.AreEqual("myPage", asResult?.PageName);
        }

        /// <summary>
        /// Ensures the execute command method is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteCommand_WithResponse_PageName_IsCorrect()
        {
            var result = await _testPage.Command(TestObjectRequest.Valid(), "myPage");

            var asResult = result as RedirectToPageResult;

            Assert.AreEqual("myPage", asResult?.PageName);
        }

        /// <summary>
        /// Ensures the execute command method is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteCommand_ResultFunc_PageName_IsCorrect()
        {
            const string pageName = "myPage";
            const string pageHandler = "myHandler";
            var routeValues = new RouteValueDictionary(new { Id = 1 });

            var result = await _testPage.Command(TestObjectRequest.Valid(), _ => (pageName, pageHandler, routeValues));

            var asResult = result as RedirectToPageResult;

            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues["Id"], asResult?.RouteValues?["Id"]);
        }

        private class UnitRequest : IEnvelopeRequest
        {
        }

        private class TestPage : MediatorBuddyStandardPage<TestResponse>
        {
            public TestPage(IMediator mediator, Func<RazorErrorWrapper, IActionResult?>? extraOptions = null)
                : base(mediator, extraOptions)
            {
            }

            public async Task<IActionResult> Query<TResponse>(IEnvelopeRequest<TResponse> request)
                where TResponse : TestResponse
            {
                return await ExecuteQuery(request);
            }

            public async Task<IActionResult> Query<TResponse>(IEnvelopeRequest<TResponse> request, Func<TResponse, TestResponse> func)
            {
                return await ExecuteQuery(request, func);
            }

            public async Task<IActionResult> Command(IEnvelopeRequest request, string pageName)
            {
                return await ExecuteCommand(request, pageName);
            }

            public async Task<IActionResult> Command<TResponse>(IEnvelopeRequest<TResponse> request, string pageName)
            {
                return await ExecuteCommand(request, pageName);
            }

            public async Task<IActionResult> Command<TResponse>(IEnvelopeRequest<TResponse> request, Func<TResponse, (string? PageName, string? PageHandler, RouteValueDictionary? RouteValues)> resultFunc)
            {
                return await ExecuteCommand(request, resultFunc);
            }
        }
    }
}
