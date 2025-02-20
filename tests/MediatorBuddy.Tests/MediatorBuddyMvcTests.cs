// <copyright file="MediatorBuddyMvcTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests for the mediator buddy mvc controller.
    /// </summary>
    [TestClass]
    public class MediatorBuddyMvcTests
    {
        private readonly Mock<IMediator> _mediator;
        private TestMediatorMvcController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyMvcTests"/> class.
        /// </summary>
        public MediatorBuddyMvcTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new TestMediatorMvcController(_mediator.Object);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task InvalidModel_ReturnsToPage()
        {
            var result = await _controller.TestEndpoint(TestObjectRequest.InValid());

            Assert.IsInstanceOfType<ViewResult>(result);
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

            var result = await _controller.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
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

            var result = await _controller.TestEndpoint(TestObjectRequest.Valid());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual("Error", asResult?.ActionName);
            Assert.AreEqual("Home", asResult?.ControllerName);
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

            var result = await _controller.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on using error options.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task ExtraOptions_IsCorrect()
        {
            static IActionResult ExtraOptions(RazorErrorWrapper wrapper) => new RedirectToRouteResult("route", new RouteValueDictionary());

            _controller = new TestMediatorMvcController(_mediator.Object, ExtraOptions);

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _controller.TestEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task InvalidModel_RazorData_ReturnsToPage()
        {
            var result = await _controller.TestRazorDataEndpoint(TestObjectRequest.InValid());

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task Success_RazorData_ReturnsToSpecifiedResult()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.Success(new TestResponse()));

            var result = await _controller.TestRazorDataEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on invalid model state.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task Exception_RazorData_ReturnsToRedirect()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _controller.TestRazorDataEndpoint(TestObjectRequest.Valid());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual("Error", asResult?.ActionName);
            Assert.AreEqual("Home", asResult?.ControllerName);
        }

        /// <summary>
        /// Ensures the correct response on no response option.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task NoOption_RazorData_ReturnsPage()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _controller.TestRazorDataEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        /// <summary>
        /// Ensures the correct response on using error options.
        /// </summary>
        /// <returns>A <see cref="Task"/> respresnting the operation.</returns>
        [TestMethod]
        public async Task ExtraOptions_RazorData_IsCorrect()
        {
            static IActionResult ExtraOptions(RazorErrorWrapper wrapper) => new RedirectToRouteResult("route", new RouteValueDictionary());

            _controller = new TestMediatorMvcController(_mediator.Object, ExtraOptions);

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(Envelope<TestResponse>.AccountIsLockedOut());

            var result = await _controller.TestRazorDataEndpoint(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
        }
    }
}
