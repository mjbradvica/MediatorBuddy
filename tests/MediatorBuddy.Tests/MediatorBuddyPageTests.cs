// <copyright file="MediatorBuddyPageTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests for the mediator buddy page controller class.
    /// </summary>
    [TestClass]
    public class MediatorBuddyPageTests
    {
        private readonly Mock<IMediator> _mediator;
        private TestMediatorPage _page;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyPageTests"/> class.
        /// </summary>
        public MediatorBuddyPageTests()
        {
            _mediator = new Mock<IMediator>();
            _page = new TestMediatorPage(_mediator.Object);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task InvalidModel_ReturnsToPage()
        {
            var result = await _page.TestEndpoint(TestObjectRequest.InValid());

            Assert.IsInstanceOfType<PageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task Success_ReturnsToSpecifiedResult()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.Success(new TestResponse()));

            var result = await _page.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task Exception_ReturnsToRedirect()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _page.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on no response option.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task NoOption_ReturnsPage()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _page.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<PageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on using error options.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task ExtraOptions_IsCorrect()
        {
            static IActionResult ExtraOptions(RazorErrorWrapper wrapper) => new RedirectToRouteResult("route", new RouteValueDictionary());

            _page = new TestMediatorPage(_mediator.Object, ExtraOptions);

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _page.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task InvalidModel_Action_ReturnsToPage()
        {
            var result = await _page.TestActionEndpoint(TestObjectRequest.InValid());

            Assert.IsInstanceOfType<PageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task Success_Action_ReturnsToSpecifiedResult()
        {
            var expected = new TestResponse();

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.Success(expected));

            var result = await _page.TestActionEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<PageResult>(result);
            Assert.AreEqual(expected, _page.ViewModel);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task Exception_Action_ReturnsToRedirect()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _page.TestActionEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on no response option.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task NoOption_Action_ReturnsPage()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _page.TestActionEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<PageResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on using error options.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task ExtraOptions_Action_IsCorrect()
        {
            static IActionResult ExtraOptions(RazorErrorWrapper wrapper) => new RedirectToRouteResult("route", new RouteValueDictionary());

            _page = new TestMediatorPage(_mediator.Object, ExtraOptions);

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _page.TestActionEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
        }
    }
}
