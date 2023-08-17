using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="MediatorBuddyApi"/> class capabilities.
    /// </summary>
    [TestClass]
    public class BaseControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private TestMediatApiController _apiController;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControllerTests"/> class.
        /// </summary>
        public BaseControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _apiController = new TestMediatApiController(_mediator.Object);
        }

        /// <summary>
        /// Ensures the correct response when validation fails.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnValidationFailures_ReturnsBadRequest()
        {
            var result = await _apiController.Handle(TestObjectRequest.InValid());

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
            var envelope = Envelope<TestResponse>.Success(response);

            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ReturnsAsync(envelope);

            _apiController = new TestMediatApiController(_mediator.Object);

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response, (result as OkObjectResult)?.Value);
        }

        /// <summary>
        /// Ensures the correct response on an exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteRequest_OnException_ReturnsBadRequest()
        {
            _mediator.Setup(x => x.Send(It.IsAny<TestObjectRequest>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _apiController.Handle(TestObjectRequest.Valid());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, (result as StatusCodeResult)?.StatusCode);
        }
    }
}
