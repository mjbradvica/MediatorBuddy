using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NMediatController.ASPNET;

namespace NMediatController.Tests
{
    /// <summary>
    /// Tests the <see cref="BaseMediatController"/> class capabilities.
    /// </summary>
    [TestClass]
    public class BaseControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly TestMediatController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControllerTests"/> class.
        /// </summary>
        public BaseControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new TestMediatController(_mediator.Object);
        }

        /// <summary>
        /// Ensures the correct response when validation fails.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnValidationFailures_ReturnsBadRequest()
        {
            var result = await _controller.Handle(TestObjectRequest.InValid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        /// <summary>
        /// Ensures the correct response when a success occurs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnSuccess_ReturnsCorrectResult()
        {
            var response = new TestResponse { Value = "success" };

            _mediator.Setup(x => x.Send(It.IsAny<IRequest<TestResponse>>(), CancellationToken.None))
                .ReturnsAsync(response);

            var result = await _controller.Handle(TestObjectRequest.Valid()) as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(response, result.Value);
        }

        /// <summary>
        /// Ensures the correct response on an exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnException_ReturnsBadRequest()
        {
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<TestResponse>>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _controller.Handle(TestObjectRequest.InValid());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
