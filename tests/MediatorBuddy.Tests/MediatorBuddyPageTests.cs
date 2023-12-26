// <copyright file="MediatorBuddyPageTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private readonly TestMediatorPage _page;

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
    }
}
